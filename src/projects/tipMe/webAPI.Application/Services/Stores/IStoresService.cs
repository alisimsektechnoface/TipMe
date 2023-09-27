using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Stores;

public interface IStoresService
{
    Task<Store?> GetAsync(
        Expression<Func<Store, bool>> predicate,
        Func<IQueryable<Store>, IIncludableQueryable<Store, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Store>?> GetListAsync(
        Expression<Func<Store, bool>>? predicate = null,
        Func<IQueryable<Store>, IOrderedQueryable<Store>>? orderBy = null,
        Func<IQueryable<Store>, IIncludableQueryable<Store, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Store> AddAsync(Store store);
    Task<Store> UpdateAsync(Store store);
    Task<Store> DeleteAsync(Store store, bool permanent = false);
}
