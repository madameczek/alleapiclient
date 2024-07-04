using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace costcollector.Infrastructure.Persistence.EntitiesConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(e => e.Id).HasName("PK_panel_lista");

        entity.ToTable("OrderTable");

        entity.HasIndex(e => new { e.OrderId, e.StoreId }, "si").IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.ErpOrderId).HasColumnName("erpOrderId");
        entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");
        entity.Property(e => e.StoreId).HasColumnName("storeId");
        entity.Property(e => e.OrderId)
            .HasMaxLength(45)
            .IsUnicode(false)
            .HasColumnName("orderId");
    }
}