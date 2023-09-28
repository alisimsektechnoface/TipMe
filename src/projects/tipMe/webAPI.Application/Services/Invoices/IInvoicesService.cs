using Application.Features.Invoices.Queries.GetByQrCode;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Invoices;

public interface IInvoicesService
{
    Task<Invoice?> GetAsync(
        Expression<Func<Invoice, bool>> predicate,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Invoice>?> GetListAsync(
        Expression<Func<Invoice, bool>>? predicate = null,
        Func<IQueryable<Invoice>, IOrderedQueryable<Invoice>>? orderBy = null,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Invoice> AddAsync(Invoice invoice);
    Task<Invoice> UpdateAsync(Invoice invoice);
    Task<Invoice> DeleteAsync(Invoice invoice, bool permanent = false);
    Task<GetByQrCodeResponse> GetByQrCode(string qrCode, CancellationToken cancellationToken);
}
