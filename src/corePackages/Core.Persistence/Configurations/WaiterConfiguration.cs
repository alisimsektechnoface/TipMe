using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class WaiterConfiguration : BaseConfiguration<Waiter,Guid>
{
    public override void Configure(EntityTypeBuilder<Waiter> builder)
    {
        
                builder.Property(w => w.StoreId).HasColumnName("StoreId");
                builder.Property(w => w.Name).HasColumnName("Name");
                builder.Property(w => w.Photo).HasColumnName("Photo");
       
    }
}