using Application.Features.Waiters.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Waiters.Rules;

public class WaiterBusinessRules : BaseBusinessRules
{
    private readonly IWaiterRepository _waiterRepository;

    public WaiterBusinessRules(IWaiterRepository waiterRepository)
    {
        _waiterRepository = waiterRepository;
    }

    public Task WaiterShouldExistWhenSelected(Waiter? waiter)
    {
        if (waiter == null)
            throw new BusinessException(WaitersBusinessMessages.WaiterNotExists);
        return Task.CompletedTask;
    }

    public async Task WaiterIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Waiter? waiter = await _waiterRepository.GetAsync(
            predicate: w => w.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await WaiterShouldExistWhenSelected(waiter);
    }
}