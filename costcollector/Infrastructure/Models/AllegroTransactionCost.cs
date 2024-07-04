namespace costcollector.Infrastructure.Models;

public class AllegroTransactionCost : AllegroCostBase
{
    public AllegroOffer Offer { get; set; }
    public AllegroOrder Order { get; set; }
}

public record AllegroOffer(long Id, string Name);

public record AllegroOrder(Guid Id);