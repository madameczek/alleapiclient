using System.Text.Json;
using costcollector.App.Interfaces;
using costcollector.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace costcollector.Infrastructure.HttpClients;

public interface IAllegroClient
{
    public Task<IEnumerable<AllegroCostBase>> GetPayments(Guid? orderId = null);
}

public class AllegroClient : IAllegroClient
{
    private readonly HttpClient _client;
    private readonly IPaymentParser _parser;

    public AllegroClient(HttpClient client, IPaymentParser parser)
    {
        _client = client;
        _parser = parser;
    }

    public async Task<IEnumerable<AllegroCostBase>> GetPayments(Guid? orderId)
    {
        QueryString queryString; 
        if(orderId is not null)
            queryString = QueryString.Create("order.id", orderId.ToString()!);
        
        var response = await _client.GetAsync($"billing/billing-entries{queryString}");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(content);
        var root = doc.RootElement.GetProperty("billingEntries");
        return _parser.Parse(root);
    }
}