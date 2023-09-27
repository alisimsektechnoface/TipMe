using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class StoreConfiguration : BaseConfiguration<Store,Guid>
{
    public override void Configure(EntityTypeBuilder<Store> builder)
    {
        
                builder.Property(s => s.Name).HasColumnName("Name");
       
    }
}