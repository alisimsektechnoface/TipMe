using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Tip : Entity<Guid>
    {
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

        public Tip()
        {
        }

        public Tip(Guid id, DateTime requestDate, string? qrCode, decimal? tipAmount, bool? isTipped, DateTime? paymentDate, string? paymentReference, bool? isCommented, string? comment, DateTime? commentDate, int? point) : this()
        {
            Id = id;
            RequestDate = requestDate;
            QrCode = qrCode;
            TipAmount = tipAmount;
            IsTipped = isTipped;
            PaymentDate = paymentDate;
            PaymentReference = paymentReference;
            IsCommented = isCommented;
            Comment = comment;
            CommentDate = commentDate;
            Point = point;
        }
    }
}
