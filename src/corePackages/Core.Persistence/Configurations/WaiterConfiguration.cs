using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class WaiterConfiguration : BaseConfiguration<Waiter, Guid>
{
    public override void Configure(EntityTypeBuilder<Waiter> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.WAITER);
        builder.Property(w => w.StoreId).HasColumnName("StoreId");
        builder.HasOne(w => w.Store).WithMany().HasForeignKey(w => w.StoreId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(w => w.Name).HasColumnName("Name").HasMaxLength(100);
        builder.Property(w => w.Photo).HasColumnName("Photo").HasMaxLength(2000);

    }
}