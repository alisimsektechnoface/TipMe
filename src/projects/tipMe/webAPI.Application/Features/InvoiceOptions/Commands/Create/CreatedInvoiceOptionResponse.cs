using Core.Application.Responses;

namespace Application.Features.InvoiceOptions.Commands.Create;

public class CreatedInvoiceOptionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }
}