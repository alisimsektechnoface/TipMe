using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class StoreConfiguration : BaseConfiguration<Store, Guid>
{
    public override void Configure(EntityTypeBuilder<Store> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.STORE);
        builder.Property(s => s.Name).HasColumnName("Name").HasMaxLength(100);
        builder.Property(w => w.Photo).HasColumnName("Photo").IsRequired(false);
    }
}