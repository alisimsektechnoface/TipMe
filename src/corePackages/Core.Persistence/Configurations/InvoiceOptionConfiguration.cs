using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class InvoiceOptionConfiguration : BaseConfiguration<InvoiceOption, Guid>
{
    public override void Configure(EntityTypeBuilder<InvoiceOption> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.INVOICE_OPTION);
        builder.Property(io => io.InvoiceId).HasColumnName("InvoiceId");
        builder.HasOne(w => w.Invoice).WithMany().HasForeignKey(w => w.InvoiceId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(io => io.OptionId).HasColumnName("OptionId");
        builder.HasOne(w => w.Option).WithMany().HasForeignKey(w => w.OptionId).OnDelete(DeleteBehavior.Restrict);

    }
}