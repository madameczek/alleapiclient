namespace costcollector.Infrastructure.Models;

public class AllegroCostBase
{
    public Guid Id { get; set; }
    public DateTime OccurredAt { get; set; }
    public AllegroType Type { get; set; } = null!;
    public AllegroValue Value { get; set; } = null!;
    public AllegroTax Tax { get; set; } = null!;
}

public record AllegroType(string Id, string Name);

public record AllegroValue(decimal Amount, string Currency);

public record AllegroTax(double Percentage);