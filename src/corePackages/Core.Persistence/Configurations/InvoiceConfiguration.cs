using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class InvoiceConfiguration : BaseConfiguration<Invoice, Guid>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.INVOICE);
        builder.Property(i => i.InvoiceDate).HasColumnName("InvoiceDate");
        builder.Property(i => i.TipId).HasColumnName("TipId").IsRequired(false);
        builder.HasOne(w => w.Tip).WithMany().HasForeignKey(w => w.TipId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(i => i.StoreId).HasColumnName("StoreId");
        builder.HasOne(w => w.Store).WithMany().HasForeignKey(w => w.StoreId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(i => i.WaiterId).HasColumnName("WaiterId");
        builder.HasOne(w => w.Waiter).WithMany().HasForeignKey(w => w.WaiterId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(i => i.Amount).HasColumnName("Amount").HasPrecision(18, 2);
        builder.Property(i => i.TipDate).HasColumnName("TipDate").IsRequired(false);
        builder.Property(i => i.IsTipped).HasColumnName("IsTipped");
        builder.Property(i => i.QrCode).HasColumnName("QrCode").HasMaxLength(250);
        builder.Property(i => i.Currency).HasColumnName("Currency").HasMaxLength(5);
        builder.HasIndex(i => i.QrCode);
    }
}