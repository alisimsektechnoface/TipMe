using Application.Features.InvoiceOptions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.InvoiceOptions.Rules;

public class InvoiceOptionBusinessRules : BaseBusinessRules
{
    private readonly IInvoiceOptionRepository _invoiceOptionRepository;

    public InvoiceOptionBusinessRules(IInvoiceOptionRepository invoiceOptionRepository)
    {
        _invoiceOptionRepository = invoiceOptionRepository;
    }

    public Task InvoiceOptionShouldExistWhenSelected(InvoiceOption? invoiceOption)
    {
        if (invoiceOption == null)
            throw new BusinessException(InvoiceOptionsBusinessMessages.InvoiceOptionNotExists);
        return Task.CompletedTask;
    }

    public async Task InvoiceOptionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        InvoiceOption? invoiceOption = await _invoiceOptionRepository.GetAsync(
            predicate: io => io.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InvoiceOptionShouldExistWhenSelected(invoiceOption);
    }
}