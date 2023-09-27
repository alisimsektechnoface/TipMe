using Application.Features.Waiters.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Waiters;

public class WaitersManager : IWaitersService
{
    private readonly IWaiterRepository _waiterRepository;
    private readonly WaiterBusinessRules _waiterBusinessRules;

    public WaitersManager(IWaiterRepository waiterRepository, WaiterBusinessRules waiterBusinessRules)
    {
        _waiterRepository = waiterRepository;
        _waiterBusinessRules = waiterBusinessRules;
    }

    public async Task<Waiter?> GetAsync(
        Expression<Func<Waiter, bool>> predicate,
        Func<IQueryable<Waiter>, IIncludableQueryable<Waiter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Waiter? waiter = await _waiterRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return waiter;
    }

    public async Task<IPaginate<Waiter>?> GetListAsync(
        Expression<Func<Waiter, bool>>? predicate = null,
        Func<IQueryable<Waiter>, IOrderedQueryable<Waiter>>? orderBy = null,
        Func<IQueryable<Waiter>, IIncludableQueryable<Waiter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Waiter> waiterList = await _waiterRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return waiterList;
    }

    public async Task<Waiter> AddAsync(Waiter waiter)
    {
        Waiter addedWaiter = await _waiterRepository.AddAsync(waiter);

        return addedWaiter;
    }

    public async Task<Waiter> UpdateAsync(Waiter waiter)
    {
        Waiter updatedWaiter = await _waiterRepository.UpdateAsync(waiter);

        return updatedWaiter;
    }

    public async Task<Waiter> DeleteAsync(Waiter waiter, bool permanent = false)
    {
        Waiter deletedWaiter = await _waiterRepository.DeleteAsync(waiter);

        return deletedWaiter;
    }
}
