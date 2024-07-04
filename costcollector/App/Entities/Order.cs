namespace costcollector.App.Entities;

public class Order
{
    public int Id { get; set; }
    public Guid OrderId { get; set; }
    public int? ErpOrderId { get; set; }
    public int? InvoiceId { get; set; }
    public int? StoreId { get; set; }
    
    public virtual IEnumerable<OrderEntry>? Entries { get; set; }
}
