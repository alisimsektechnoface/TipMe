using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Waiters;

public interface IWaitersService
{
    Task<Waiter?> GetAsync(
        Expression<Func<Waiter, bool>> predicate,
        Func<IQueryable<Waiter>, IIncludableQueryable<Waiter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Waiter>?> GetListAsync(
        Expression<Func<Waiter, bool>>? predicate = null,
        Func<IQueryable<Waiter>, IOrderedQueryable<Waiter>>? orderBy = null,
        Func<IQueryable<Waiter>, IIncludableQueryable<Waiter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Waiter> AddAsync(Waiter waiter);
    Task<Waiter> UpdateAsync(Waiter waiter);
    Task<Waiter> DeleteAsync(Waiter waiter, bool permanent = false);
}
