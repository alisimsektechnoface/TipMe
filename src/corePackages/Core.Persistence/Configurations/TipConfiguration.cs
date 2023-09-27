using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class TipConfiguration : BaseConfiguration<Tip,Guid>
{
    public override void Configure(EntityTypeBuilder<Tip> builder)
    {
        
                builder.Property(t => t.RequestDate).HasColumnName("RequestDate");
                builder.Property(t => t.QrCode).HasColumnName("QrCode");
                builder.Property(t => t.IsTipped).HasColumnName("IsTipped");
                builder.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
                builder.Property(t => t.PaymentReference).HasColumnName("PaymentReference");
                builder.Property(t => t.IsCommented).HasColumnName("IsCommented");
                builder.Property(t => t.Comment).HasColumnName("Comment");
                builder.Property(t => t.CommentDate).HasColumnName("CommentDate");
                builder.Property(t => t.Point).HasColumnName("Point");
       
    }
}