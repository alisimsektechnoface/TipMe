using Application.Features.Invoices.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Invoices.Rules;

public class InvoiceBusinessRules : BaseBusinessRules
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceBusinessRules(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public Task InvoiceShouldExistWhenSelected(Invoice? invoice)
    {
        if (invoice == null)
            throw new BusinessException(InvoicesBusinessMessages.InvoiceNotExists);
        return Task.CompletedTask;
    }

    public async Task InvoiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InvoiceShouldExistWhenSelected(invoice);
    }
}