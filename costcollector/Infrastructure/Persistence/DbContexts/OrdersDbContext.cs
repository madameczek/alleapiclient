using costcollector.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace costcollector.Infrastructure.Persistence.DbContexts;

public class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderEntry> Offers { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(new List<Order>
        {
            new() { Id = 1, OrderId = new Guid("024ac720-3857-11ef-ac0a-e5fcc384aba0"), ErpOrderId = 1, InvoiceId = 12, StoreId = 21 },
            new() { Id = 2, OrderId = new Guid("64f97c00-3847-11ef-ac0a-e5fcc384aba0"), ErpOrderId = 2, InvoiceId = 13, StoreId = 21 }
        });
        modelBuilder.Entity<OrderEntry>().HasData(new List<OrderEntry>
        {
            new() { Id = 1, OrderId = 1, OfferId = "7770594916" },
            new() { Id = 2, OrderId = 1, OfferId = "7770594916" },
        });
        modelBuilder.Entity<PaymentType>().HasData(new List<PaymentType>
        {
            new() { Id = "USF", Description = "Jednostkowa opłata transakcyjna" },
            new() { Id = "SUC", Description = "Prowizja od sprzedaży" },
            new() { Id = "SUM", Description = "Podsumowanie miesiąca" },
            new() { Id = "PB2", Description = "Wpłata" },
            new() { Id = "VEP", Description = "Naliczenie VAT e-commerce" },
            new() { Id = "ST4", Description = "Abonament za statystyki - 12 miesięcy" },
            new() { Id = "RIC", Description = "Korekta salda" },
            new() { Id = "RES", Description = "Opłata za cenę minimalną" }
        });
        modelBuilder.Entity<PaymentCategory>().HasData(new List<PaymentCategory>
        {
            new() { Id = 1, Name = "Koszty stałe" },
            new() { Id = 2, Name = "Koszty zmienne"}
        });
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}