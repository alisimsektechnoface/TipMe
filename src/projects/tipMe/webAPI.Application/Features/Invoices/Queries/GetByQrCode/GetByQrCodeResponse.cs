using Application.Features.Options.Queries.GetOptionsWithGroup;
using Application.Features.Waiters.Queries.GetById;
using Core.Application.Responses;

namespace Application.Features.Invoices.Queries.GetByQrCode;

public class GetByQrCodeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? TipId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public Guid WaiterId { get; set; }
    public decimal Amount { get; set; }
    public DateTime? TipDate { get; set; }
    public bool IsTipped { get; set; }
    public string QrCode { get; set; }
    public string Currency { get; set; }
    public GetByIdWaiterResponse Waiter { get; set; }
    public GetOptionsWithGroupResponse Options { get; set; }
}
