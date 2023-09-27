using Core.Application.Responses;

namespace Application.Features.InvoiceOptions.Queries.GetById;

public class GetByIdInvoiceOptionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }
}