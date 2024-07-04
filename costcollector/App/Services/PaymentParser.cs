using System.Text.Json;
using costcollector.App.Interfaces;
using costcollector.Infrastructure.Models;

namespace costcollector.App.Services;

public class PaymentParser : IPaymentParser
{
    private readonly ICostTypeProvider _costTypeProvider;
    private readonly JsonSerializerOptions _serializerOptions;

    public PaymentParser(ICostTypeProvider costTypeProvider, JsonSerializerOptions serializerOptions)
    {
        _costTypeProvider = costTypeProvider;
        _serializerOptions = serializerOptions;
    }

    public IEnumerable<AllegroCostBase> Parse(JsonElement root)
    {
        List<AllegroCostBase> payments = [];
        var transactionCostTypes = _costTypeProvider.GetTransactionCostTypes().ToArray();
        
        foreach (var payment in root.EnumerateArray())
        {
            var typeElement = payment.GetProperty("type");
            var type = typeElement.Deserialize<AllegroType>(_serializerOptions);
            
            if(type is null) continue;

            payments.Add(transactionCostTypes.Contains(type.Id)
                ? payment.Deserialize<AllegroTransactionCost>(_serializerOptions)!
                : payment.Deserialize<AllegroCostBase>(_serializerOptions)!);
        }

        return payments;
    }
}