using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Tips;

public class TipsManager : ITipsService
{
    private readonly ITipRepository _tipRepository;
    private readonly TipBusinessRules _tipBusinessRules;

    public TipsManager(ITipRepository tipRepository, TipBusinessRules tipBusinessRules)
    {
        _tipRepository = tipRepository;
        _tipBusinessRules = tipBusinessRules;
    }

    public async Task<Tip?> GetAsync(
        Expression<Func<Tip, bool>> predicate,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Tip? tip = await _tipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return tip;
    }

    public async Task<IPaginate<Tip>?> GetListAsync(
        Expression<Func<Tip, bool>>? predicate = null,
        Func<IQueryable<Tip>, IOrderedQueryable<Tip>>? orderBy = null,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Tip> tipList = await _tipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return tipList;
    }

    public async Task<Tip> AddAsync(Tip tip)
    {
        Tip addedTip = await _tipRepository.AddAsync(tip);

        return addedTip;
    }

    public async Task<Tip> UpdateAsync(Tip tip)
    {
        Tip updatedTip = await _tipRepository.UpdateAsync(tip);

        return updatedTip;
    }

    public async Task<Tip> DeleteAsync(Tip tip, bool permanent = false)
    {
        Tip deletedTip = await _tipRepository.DeleteAsync(tip);

        return deletedTip;
    }
}
