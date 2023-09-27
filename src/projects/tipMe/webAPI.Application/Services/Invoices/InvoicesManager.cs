using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Invoices;

public class InvoicesManager : IInvoicesService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly InvoiceBusinessRules _invoiceBusinessRules;

    public InvoicesManager(IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
    {
        _invoiceRepository = invoiceRepository;
        _invoiceBusinessRules = invoiceBusinessRules;
    }

    public async Task<Invoice?> GetAsync(
        Expression<Func<Invoice, bool>> predicate,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return invoice;
    }

    public async Task<IPaginate<Invoice>?> GetListAsync(
        Expression<Func<Invoice, bool>>? predicate = null,
        Func<IQueryable<Invoice>, IOrderedQueryable<Invoice>>? orderBy = null,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Invoice> invoiceList = await _invoiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return invoiceList;
    }

    public async Task<Invoice> AddAsync(Invoice invoice)
    {
        Invoice addedInvoice = await _invoiceRepository.AddAsync(invoice);

        return addedInvoice;
    }

    public async Task<Invoice> UpdateAsync(Invoice invoice)
    {
        Invoice updatedInvoice = await _invoiceRepository.UpdateAsync(invoice);

        return updatedInvoice;
    }

    public async Task<Invoice> DeleteAsync(Invoice invoice, bool permanent = false)
    {
        Invoice deletedInvoice = await _invoiceRepository.DeleteAsync(invoice);

        return deletedInvoice;
    }
}
