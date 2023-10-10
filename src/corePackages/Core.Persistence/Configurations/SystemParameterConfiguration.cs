using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class SystemParameterConfiguration : BaseConfiguration<SystemParameter,Guid>
{
    public override void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        base.Configure(builder);
        builder.ToTable("SystemParameters");
        
                builder.Property(sp => sp.ParameterKey).HasColumnName("ParameterKey");
                
                builder.Property(sp => sp.ParameterValue).HasColumnName("ParameterValue");
                
                builder.Property(sp => sp.SampleValue).HasColumnName("SampleValue");
                
                builder.Property(sp => sp.Description).HasColumnName("Description");
                
       
    }
}