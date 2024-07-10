namespace costcollector.App.Entities;

public class Payment
{
    public int Id { get; set; }
    public Guid AllegroId { get; set; }
    public DateTimeOffset OccuredAt { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
    public double TaxPercentage { get; set; }
    public string PaymentTypeId { get; set; } = null!;
    
    public virtual PaymentType Type { get; set; } = null!;
}