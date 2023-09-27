using Core.Application.Responses;

namespace Application.Features.Invoices.Commands.Create;

public class CreatedInvoiceResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public Guid StoreId { get; set; }
    public Guid WaiterId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TipDate { get; set; }
    public bool IsTipped { get; set; }
    public string QrCode { get; set; }
    public string Currency { get; set; }
}