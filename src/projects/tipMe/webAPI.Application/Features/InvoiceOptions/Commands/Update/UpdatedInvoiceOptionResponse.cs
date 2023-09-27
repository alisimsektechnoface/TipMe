using Core.Application.Responses;

namespace Application.Features.InvoiceOptions.Commands.Update;

public class UpdatedInvoiceOptionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }
}