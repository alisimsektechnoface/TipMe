using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class OptionConfiguration : BaseConfiguration<Option,Guid>
{
    public override void Configure(EntityTypeBuilder<Option> builder)
    {
        
                builder.Property(o => o.Name).HasColumnName("Name");
                builder.Property(o => o.Icon).HasColumnName("Icon");
                builder.Property(o => o.IsHappy).HasColumnName("IsHappy");
       
    }
}