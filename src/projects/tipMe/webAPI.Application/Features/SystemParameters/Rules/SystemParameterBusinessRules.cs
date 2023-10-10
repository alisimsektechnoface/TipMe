using Application.Features.SystemParameters.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.SystemParameters.Rules;

public class SystemParameterBusinessRules : BaseBusinessRules
{
    private readonly ISystemParameterRepository _systemParameterRepository;

    public SystemParameterBusinessRules(ISystemParameterRepository systemParameterRepository)
    {
        _systemParameterRepository = systemParameterRepository;
    }

    public Task SystemParameterShouldExistWhenSelected(SystemParameter? systemParameter)
    {
        if (systemParameter == null)
            throw new BusinessException(SystemParametersBusinessMessages.SystemParameterNotExists);
        return Task.CompletedTask;
    }

    public async Task SystemParameterIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(
            predicate: sp => sp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SystemParameterShouldExistWhenSelected(systemParameter);
    }
}