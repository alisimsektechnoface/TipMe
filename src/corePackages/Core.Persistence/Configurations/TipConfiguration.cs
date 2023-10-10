using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class TipConfiguration : BaseConfiguration<Tip, Guid>
{
    public override void Configure(EntityTypeBuilder<Tip> builder)
    {

        base.Configure(builder);
        builder.ToTable(TableNameConstants.TIP);
        builder.Property(t => t.RequestDate).HasColumnName("RequestDate");
        builder.Property(t => t.QrCode).HasColumnName("QrCode").HasMaxLength(250);
        builder.Property(t => t.TipAmount).HasColumnName("TipAmount").IsRequired(false).HasPrecision(18, 2);
        builder.Property(t => t.TaxAmount).HasColumnName("TaxAmount").IsRequired(false).HasPrecision(18, 2).HasDefaultValue(Convert.ToDecimal(0));
        builder.Property(t => t.IsTipped).HasColumnName("IsTipped").IsRequired(false);
        builder.Property(t => t.PaymentDate).HasColumnName("PaymentDate").IsRequired(false);
        builder.Property(t => t.PaymentReference).HasColumnName("PaymentReference").IsRequired(false).HasMaxLength(500);
        builder.Property(t => t.IsCommented).HasColumnName("IsCommented").IsRequired(false);
        builder.Property(t => t.Comment).HasColumnName("Comment").IsRequired(false);
        builder.Property(t => t.CommentDate).HasColumnName("CommentDate").IsRequired(false);
        builder.Property(t => t.Point).HasColumnName("Point").IsRequired(false);
        builder.HasIndex(i => i.QrCode);

    }
}