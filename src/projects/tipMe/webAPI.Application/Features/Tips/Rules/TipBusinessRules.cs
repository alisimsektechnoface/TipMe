using Application.Features.Tips.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Tips.Rules;

public class TipBusinessRules : BaseBusinessRules
{
    private readonly ITipRepository _tipRepository;

    public TipBusinessRules(ITipRepository tipRepository)
    {
        _tipRepository = tipRepository;
    }

    public Task TipShouldExistWhenSelected(Tip? tip)
    {
        if (tip == null)
            throw new BusinessException(TipsBusinessMessages.TipNotExists);
        return Task.CompletedTask;
    }

    public async Task TipIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Tip? tip = await _tipRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TipShouldExistWhenSelected(tip);
    }
}