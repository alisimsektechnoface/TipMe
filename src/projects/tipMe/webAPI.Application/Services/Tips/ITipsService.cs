using Core.Domain.Entities;
using Core.Persistence.Paging;
using Iyzipay.Model;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Tips;

public interface ITipsService
{
    Task<Tip?> GetAsync(
        Expression<Func<Tip, bool>> predicate,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Tip>?> GetListAsync(
        Expression<Func<Tip, bool>>? predicate = null,
        Func<IQueryable<Tip>, IOrderedQueryable<Tip>>? orderBy = null,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Tip> AddAsync(Tip tip);
    Task<Tip> UpdateAsync(Tip tip);
    Task<Tip> DeleteAsync(Tip tip, bool permanent = false);
    Task<CheckoutFormInitialize> PaymentRequest(decimal tipAmount, string redirectUrl, Invoice invoice);
    Task<CheckoutForm> PaymentResult(string token);
}
