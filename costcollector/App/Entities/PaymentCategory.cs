namespace costcollector.App.Entities;

public class PaymentCategory
{
    public int id { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<PaymentType>? Types { get; set; }
}