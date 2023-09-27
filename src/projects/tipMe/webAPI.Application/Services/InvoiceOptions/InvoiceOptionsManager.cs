using Application.Features.InvoiceOptions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InvoiceOptions;

public class InvoiceOptionsManager : IInvoiceOptionsService
{
    private readonly IInvoiceOptionRepository _invoiceOptionRepository;
    private readonly InvoiceOptionBusinessRules _invoiceOptionBusinessRules;

    public InvoiceOptionsManager(IInvoiceOptionRepository invoiceOptionRepository, InvoiceOptionBusinessRules invoiceOptionBusinessRules)
    {
        _invoiceOptionRepository = invoiceOptionRepository;
        _invoiceOptionBusinessRules = invoiceOptionBusinessRules;
    }

    public async Task<InvoiceOption?> GetAsync(
        Expression<Func<InvoiceOption, bool>> predicate,
        Func<IQueryable<InvoiceOption>, IIncludableQueryable<InvoiceOption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        InvoiceOption? invoiceOption = await _invoiceOptionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return invoiceOption;
    }

    public async Task<IPaginate<InvoiceOption>?> GetListAsync(
        Expression<Func<InvoiceOption, bool>>? predicate = null,
        Func<IQueryable<InvoiceOption>, IOrderedQueryable<InvoiceOption>>? orderBy = null,
        Func<IQueryable<InvoiceOption>, IIncludableQueryable<InvoiceOption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<InvoiceOption> invoiceOptionList = await _invoiceOptionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return invoiceOptionList;
    }

    public async Task<InvoiceOption> AddAsync(InvoiceOption invoiceOption)
    {
        InvoiceOption addedInvoiceOption = await _invoiceOptionRepository.AddAsync(invoiceOption);

        return addedInvoiceOption;
    }

    public async Task<InvoiceOption> UpdateAsync(InvoiceOption invoiceOption)
    {
        InvoiceOption updatedInvoiceOption = await _invoiceOptionRepository.UpdateAsync(invoiceOption);

        return updatedInvoiceOption;
    }

    public async Task<InvoiceOption> DeleteAsync(InvoiceOption invoiceOption, bool permanent = false)
    {
        InvoiceOption deletedInvoiceOption = await _invoiceOptionRepository.DeleteAsync(invoiceOption);

        return deletedInvoiceOption;
    }
}
