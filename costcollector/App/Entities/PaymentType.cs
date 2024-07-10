namespace costcollector.App.Entities;

public class PaymentType
{
    public string Id { get; set; } = null!;
    public string? Description { get; set; }

    public virtual IEnumerable<Payment> Payments { get; set; } = null!;
    public virtual IEnumerable<PaymentCategory>? Categories { get; set; }
}