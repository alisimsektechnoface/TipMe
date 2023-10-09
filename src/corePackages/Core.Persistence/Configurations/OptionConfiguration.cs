using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class OptionConfiguration : BaseConfiguration<Option, Guid>
{
    public override void Configure(EntityTypeBuilder<Option> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.OPTION);
        builder.Property(o => o.Name).HasColumnName("Name").HasMaxLength(100);
        builder.Property(o => o.Icon).HasColumnName("Icon").HasMaxLength(250);
        builder.Property(o => o.IsHappy).HasColumnName("IsHappy").HasDefaultValue(false);

    }
}