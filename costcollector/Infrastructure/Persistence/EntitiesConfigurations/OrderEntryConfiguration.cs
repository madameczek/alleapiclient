using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace costcollector.Infrastructure.Persistence.EntitiesConfigurations;

public class OrderEntryConfiguration : IEntityTypeConfiguration<OrderEntry>
{
    public void Configure(EntityTypeBuilder<OrderEntry> entity)
    {
        entity.HasKey(e => e.Id).IsClustered();

        entity.ToTable("OrderPositions");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.OrderId).HasColumnName("orderId");
        entity.Property(e => e.OfferId).HasColumnName("offerId")
            .HasMaxLength(45)
            .IsUnicode(false)
            .IsRequired();

        entity.HasOne(entry => entry.Order)
            .WithMany(order => order.Entries)
            .HasForeignKey(orderEntry => orderEntry.OrderId);
    }
}