using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class InvoiceOption : Entity<Guid>
    {
        public Guid InvoiceId { get; set; }
        public Guid OptionId { get; set; }

        public InvoiceOption()
        {
        }

        public InvoiceOption(Guid id, Guid invoiceId, Guid optionId) : this()
        {
            Id = id;
            InvoiceId = invoiceId;
            OptionId = optionId;
        }

    }
}
