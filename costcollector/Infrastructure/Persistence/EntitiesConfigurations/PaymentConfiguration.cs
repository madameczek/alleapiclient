using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace costcollector.Infrastructure.Persistence.EntitiesConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.ToTable("Payments");

        entity.HasIndex(e => e.AllegroId).IsUnique();

        entity.Property(e => e.Amount).HasPrecision(8, 2);
        entity.Property(e => e.Currency).HasMaxLength(3);
        entity.Property(e => e.PaymentTypeId).HasMaxLength(3);
        entity.Property(e => e.AllegroId)
            .HasMaxLength(45)
            .IsUnicode(false);

        entity.HasOne(e => e.Type)
            .WithMany(e => e.Payments)
            .HasForeignKey(e => e.PaymentTypeId);
    }
}