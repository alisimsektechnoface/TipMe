using Application.Features.Stores.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stores;

public class StoresManager : IStoresService
{
    private readonly IStoreRepository _storeRepository;
    private readonly StoreBusinessRules _storeBusinessRules;

    public StoresManager(IStoreRepository storeRepository, StoreBusinessRules storeBusinessRules)
    {
        _storeRepository = storeRepository;
        _storeBusinessRules = storeBusinessRules;
    }

    public async Task<Store?> GetAsync(
        Expression<Func<Store, bool>> predicate,
        Func<IQueryable<Store>, IIncludableQueryable<Store, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Store? store = await _storeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return store;
    }

    public async Task<IPaginate<Store>?> GetListAsync(
        Expression<Func<Store, bool>>? predicate = null,
        Func<IQueryable<Store>, IOrderedQueryable<Store>>? orderBy = null,
        Func<IQueryable<Store>, IIncludableQueryable<Store, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Store> storeList = await _storeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return storeList;
    }

    public async Task<Store> AddAsync(Store store)
    {
        Store addedStore = await _storeRepository.AddAsync(store);

        return addedStore;
    }

    public async Task<Store> UpdateAsync(Store store)
    {
        Store updatedStore = await _storeRepository.UpdateAsync(store);

        return updatedStore;
    }

    public async Task<Store> DeleteAsync(Store store, bool permanent = false)
    {
        Store deletedStore = await _storeRepository.DeleteAsync(store);

        return deletedStore;
    }
}
