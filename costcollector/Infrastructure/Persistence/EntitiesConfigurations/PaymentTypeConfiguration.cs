using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace costcollector.Infrastructure.Persistence.EntitiesConfigurations;

public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> entity)
    {
        entity.ToTable("PaymentTypes");

        entity.Property(e => e.Id).HasMaxLength(3);
        entity.Property(e => e.Description).HasMaxLength(200);

        entity.HasMany(e => e.Categories)
            .WithMany(e => e.Types)
            .UsingEntity<PaymentTypeCategory>(
            "PaymentTypeCategory",
            builder => builder.HasOne<PaymentCategory>()
                .WithMany()
                .HasForeignKey(e => e.IdPaymentCategory),
            builder => builder.HasOne<PaymentType>()
                .WithMany()
                .HasForeignKey(e => e.IdPaymentType))
            .HasData(new List<PaymentTypeCategory>
            {
                new() { IdPaymentCategory = 1, IdPaymentType = "USF" },
                new() { IdPaymentCategory = 2, IdPaymentType = "SUC" }
            });
    }
}