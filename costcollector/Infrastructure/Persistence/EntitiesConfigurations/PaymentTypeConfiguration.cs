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

        entity.HasOne(e => e.Category)
            .WithMany(e => e.Types)
            .HasForeignKey(e => e.PaymentCategoryId);
    }
}