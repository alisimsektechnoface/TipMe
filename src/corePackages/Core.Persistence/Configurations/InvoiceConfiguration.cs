using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class InvoiceConfiguration : BaseConfiguration<Invoice,Guid>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        
                builder.Property(i => i.InvoiceDate).HasColumnName("InvoiceDate");
                builder.Property(i => i.StoreId).HasColumnName("StoreId");
                builder.Property(i => i.WaiterId).HasColumnName("WaiterId");
                builder.Property(i => i.Amount).HasColumnName("Amount");
                builder.Property(i => i.TipDate).HasColumnName("TipDate");
                builder.Property(i => i.IsTipped).HasColumnName("IsTipped");
                builder.Property(i => i.QrCode).HasColumnName("QrCode");
                builder.Property(i => i.Currency).HasColumnName("Currency");
       
    }
}