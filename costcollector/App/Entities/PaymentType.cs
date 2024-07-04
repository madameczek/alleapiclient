namespace costcollector.App.Entities;

public class PaymentType
{
    public string Id { get; set; } = null!;
    public string? Description { get; set; }
    public int? PaymentCategoryId { get; set; }

    public virtual IEnumerable<Payment> Payments { get; set; } = null!;
    public virtual PaymentCategory? Category { get; set; }
}