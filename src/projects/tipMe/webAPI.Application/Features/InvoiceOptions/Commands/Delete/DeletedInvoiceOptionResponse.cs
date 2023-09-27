using Core.Application.Responses;

namespace Application.Features.InvoiceOptions.Commands.Delete;

public class DeletedInvoiceOptionResponse : IResponse
{
    public Guid Id { get; set; }
}