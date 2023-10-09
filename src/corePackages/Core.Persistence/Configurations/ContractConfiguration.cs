using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ContractConfiguration : BaseConfiguration<Contract, Guid>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        base.Configure(builder);
        builder.ToTable("Contracts");

        builder.Property(c => c.Url).HasColumnName("Url");

        builder.Property(c => c.Name).HasColumnName("Name");

        builder.Property(c => c.Description).HasColumnName("Description");

        builder.HasIndex(c => c.Url);
    }
}