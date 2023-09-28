using Core.Application.Dtos;

namespace Application.Features.Tips.Queries.GetList;

public class GetListTipListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime RequestDate { get; set; }
    public string QrCode { get; set; }
    public decimal? TipAmount { get; set; }
    public bool? IsTipped { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentReference { get; set; }
    public bool? IsCommented { get; set; }
    public string? Comment { get; set; }
    public DateTime? CommentDate { get; set; }
    public int? Point { get; set; }
}