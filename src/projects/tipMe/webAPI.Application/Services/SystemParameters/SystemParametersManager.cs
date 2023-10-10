using Application.Features.SystemParameters.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SystemParameters;

public class SystemParametersManager : ISystemParametersService
{
    private readonly ISystemParameterRepository _systemParameterRepository;
    private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

    public SystemParametersManager(ISystemParameterRepository systemParameterRepository, SystemParameterBusinessRules systemParameterBusinessRules)
    {
        _systemParameterRepository = systemParameterRepository;
        _systemParameterBusinessRules = systemParameterBusinessRules;
    }

    public async Task<SystemParameter?> GetAsync(
        Expression<Func<SystemParameter, bool>> predicate,
        Func<IQueryable<SystemParameter>, IIncludableQueryable<SystemParameter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return systemParameter;
    }

    public async Task<IPaginate<SystemParameter>?> GetListAsync(
        Expression<Func<SystemParameter, bool>>? predicate = null,
        Func<IQueryable<SystemParameter>, IOrderedQueryable<SystemParameter>>? orderBy = null,
        Func<IQueryable<SystemParameter>, IIncludableQueryable<SystemParameter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SystemParameter> systemParameterList = await _systemParameterRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return systemParameterList;
    }

    public async Task<SystemParameter> AddAsync(SystemParameter systemParameter)
    {
        SystemParameter addedSystemParameter = await _systemParameterRepository.AddAsync(systemParameter);

        return addedSystemParameter;
    }

    public async Task<SystemParameter> UpdateAsync(SystemParameter systemParameter)
    {
        SystemParameter updatedSystemParameter = await _systemParameterRepository.UpdateAsync(systemParameter);

        return updatedSystemParameter;
    }

    public async Task<SystemParameter> DeleteAsync(SystemParameter systemParameter, bool permanent = false)
    {
        SystemParameter deletedSystemParameter = await _systemParameterRepository.DeleteAsync(systemParameter);

        return deletedSystemParameter;
    }

    public async Task<SystemParameter> GetByKey(string key)
    {
        SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(b => b.ParameterKey == key);
        await _systemParameterBusinessRules.SystemParameterShouldExistWhenSelected(systemParameter);
        return systemParameter;
    }
    public async Task<string> GetValueByKey(string key)
    {
        SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(b => b.ParameterKey == key);
        await _systemParameterBusinessRules.SystemParameterShouldExistWhenSelected(systemParameter);
        return systemParameter.ParameterValue;
    }
}
