using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class InvoiceOptionConfiguration : BaseConfiguration<InvoiceOption,Guid>
{
    public override void Configure(EntityTypeBuilder<InvoiceOption> builder)
    {
        
                builder.Property(io => io.InvoiceId).HasColumnName("InvoiceId");
                builder.Property(io => io.OptionId).HasColumnName("OptionId");
       
    }
}