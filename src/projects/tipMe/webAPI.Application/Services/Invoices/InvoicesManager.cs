using Application.Features.Invoices.Queries.GetByQrCode;
using Application.Features.Invoices.Rules;
using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Queries.GetOptionsWithGroup;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Invoices;

public class InvoicesManager : IInvoicesService
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly InvoiceBusinessRules _invoiceBusinessRules;

    public InvoicesManager(IMapper mapper, IInvoiceRepository invoiceRepository, IOptionRepository optionRepository, InvoiceBusinessRules invoiceBusinessRules)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
        _optionRepository = optionRepository;
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

    public async Task<GetByQrCodeResponse> GetByQrCode(string qrCode, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.QrCode == qrCode && !i.IsTipped,
            include: i => i.Include(x => x.Store).Include(x => x.Waiter),
            cancellationToken: cancellationToken);

        await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

        GetByQrCodeResponse response = _mapper.Map<GetByQrCodeResponse>(invoice);

        var groupedItems = await _optionRepository.Query().GroupBy(item => item.IsHappy).ToListAsync();
        GetOptionsWithGroupResponse options = new GetOptionsWithGroupResponse();
        foreach (var group in groupedItems)
        {
            if (group.Key)
            {
                options.Happy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
            }
            else
            {
                options.Unhappy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
            }
        }
        response.Options = options;
        return response;
    }
}
