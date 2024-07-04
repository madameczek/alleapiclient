using System.Text.Json;
using costcollector.Infrastructure.Models;

namespace costcollector.App.Interfaces;

public interface IPaymentParser
{
    public IEnumerable<AllegroCostBase> Parse(JsonElement jsonElement);
}