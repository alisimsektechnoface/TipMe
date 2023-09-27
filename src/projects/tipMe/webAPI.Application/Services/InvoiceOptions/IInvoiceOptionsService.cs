using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InvoiceOptions;

public interface IInvoiceOptionsService
{
    Task<InvoiceOption?> GetAsync(
        Expression<Func<InvoiceOption, bool>> predicate,
        Func<IQueryable<InvoiceOption>, IIncludableQueryable<InvoiceOption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<InvoiceOption>?> GetListAsync(
        Expression<Func<InvoiceOption, bool>>? predicate = null,
        Func<IQueryable<InvoiceOption>, IOrderedQueryable<InvoiceOption>>? orderBy = null,
        Func<IQueryable<InvoiceOption>, IIncludableQueryable<InvoiceOption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<InvoiceOption> AddAsync(InvoiceOption invoiceOption);
    Task<InvoiceOption> UpdateAsync(InvoiceOption invoiceOption);
    Task<InvoiceOption> DeleteAsync(InvoiceOption invoiceOption, bool permanent = false);
}
