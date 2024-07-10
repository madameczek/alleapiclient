using costcollector.App.Entities;
using costcollector.App.Interfaces;
using costcollector.Common.Mappers;
using costcollector.Infrastructure.HttpClients;
using Microsoft.Extensions.Logging;

namespace costcollector.App.Services;

public class AllegroService : IAllegroService
{
    private readonly IAllegroClient _allegroClient;
    private readonly ILogger<AllegroService> _logger;

    public AllegroService(IAllegroClient allegroClient, ILogger<AllegroService> logger)
    {
        _allegroClient = allegroClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Payment>> FetchPayments(Guid orderId, CancellationToken ct)
    {
        try
        {
            var allegroPayments = await _allegroClient.GetPayments(orderId);

            return allegroPayments.Select(PaymentMappers.From)
                .ToList();
        }
        catch (Exception e)
        {
            // TODO implement transient IO error resilience policy
            _logger.LogError("Error message: {Message}", e.Message);
            throw;
        }
    }
}