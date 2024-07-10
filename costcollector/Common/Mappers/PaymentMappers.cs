using costcollector.App.Entities;
using costcollector.Infrastructure.Models;

namespace costcollector.Common.Mappers;

public static class PaymentMappers
{
    public static Payment From(AllegroCostBase allegroCost)
    {
        var payment = new Payment
        {
            AllegroId = allegroCost.Id,
            OccuredAt = allegroCost.OccurredAt,
            Amount = allegroCost.Value.Amount,
            Currency = allegroCost.Value.Currency,
            TaxPercentage = allegroCost.Tax.Percentage,
            Type = new PaymentType
            {
                Id = allegroCost.Type.Id,
                Description = allegroCost.Type.Name
            },
        };
        return payment;
    }
}