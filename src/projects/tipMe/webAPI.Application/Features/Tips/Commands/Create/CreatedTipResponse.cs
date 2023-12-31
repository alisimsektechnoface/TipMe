using Core.Application.Responses;

namespace Application.Features.Tips.Commands.Create;

public class CreatedTipResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime RequestDate { get; set; }
    public string? QrCode { get; set; }
    public decimal? TipAmount { get; set; }
    public decimal? TaxAmount { get; set; }
    public bool? IsTipped { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentReference { get; set; }
    public bool? IsCommented { get; set; }
    public string? Comment { get; set; }
    public DateTime? CommentDate { get; set; }
    public int? Point { get; set; }
}