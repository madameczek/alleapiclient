namespace costcollector.App.Entities;

public class PaymentCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<PaymentType>? Types { get; set; }
}