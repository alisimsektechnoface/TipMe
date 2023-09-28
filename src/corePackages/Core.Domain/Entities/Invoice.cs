using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Invoice : Entity<Guid>
    {
        public Guid? TipId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid StoreId { get; set; }
        public Guid WaiterId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? TipDate { get; set; }
        public bool IsTipped { get; set; }
        public string QrCode { get; set; }
        public string Currency { get; set; }
        public Store Store { get; set; }
        public Waiter Waiter { get; set; }
        public Tip Tip { get; set; }

        public Invoice()
        {
        }

        public Invoice(Guid id, Guid tipId, DateTime invoiceDate, Guid storeId, Guid waiterId, decimal amount, DateTime? tipDate, bool isTipped, string qrCode, string currency) : this()
        {
            Id = id;
            TipId = tipId;
            InvoiceDate = invoiceDate;
            StoreId = storeId;
            WaiterId = waiterId;
            Amount = amount;
            TipDate = tipDate;
            IsTipped = isTipped;
            QrCode = qrCode;
            Currency = currency;
        }
    }
}
