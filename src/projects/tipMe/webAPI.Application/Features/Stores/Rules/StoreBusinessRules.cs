using Application.Features.Stores.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Stores.Rules;

public class StoreBusinessRules : BaseBusinessRules
{
    private readonly IStoreRepository _storeRepository;

    public StoreBusinessRules(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public Task StoreShouldExistWhenSelected(Store? store)
    {
        if (store == null)
            throw new BusinessException(StoresBusinessMessages.StoreNotExists);
        return Task.CompletedTask;
    }

    public async Task StoreIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Store? store = await _storeRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StoreShouldExistWhenSelected(store);
    }
}