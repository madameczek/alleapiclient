using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace costcollector.Infrastructure.Persistence.EntitiesConfigurations;

public class PaymentCategoryConfiguration : IEntityTypeConfiguration<PaymentCategory>
{
    public void Configure(EntityTypeBuilder<PaymentCategory> entity)
    {
        entity.ToTable("PaymentCategories");
        
        entity.Property(e => e.Name).HasMaxLength(200);
    }
}