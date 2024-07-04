using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace costcollector.Infrastructure.Persistence.DbContexts;

public partial class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderEntry> Offers { get; set; }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(new Order
            { Id = 1, OrderId = new Guid("024ac720-3857-11ef-ac0a-e5fcc384aba0"), ErpOrderId = 1, InvoiceId = 12, StoreId = 21 });
        modelBuilder.Entity<Order>().HasData(new Order
            { Id = 2, OrderId = new Guid("64f97c00-3847-11ef-ac0a-e5fcc384aba0"), ErpOrderId = 2, InvoiceId = 13, StoreId = 21 });
        modelBuilder.Entity<OrderEntry>().HasData(new List<OrderEntry>
        {
            new() { Id = 1, OrderId = 1, OfferId = "7770594916" },
            new() { Id = 2, OrderId = 1, OfferId = "7770594916" },
        });
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}