namespace costcollector.App.Entities;

public class OrderEntry
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string OfferId { get; set; } = null!;
    
    public virtual Order Order { get; set; } = null!;
}