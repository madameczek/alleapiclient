using costcollector.App.Entities;
using costcollector.App.Interfaces;
using Microsoft.Extensions.Logging;

namespace costcollector.App.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(IPaymentRepository repository, ILogger<PaymentService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    public async Task SavePayment(Payment payment, CancellationToken cancellationToken = default)
    {
        try
        {
            await _repository.SavePayment(payment, cancellationToken);
        }
        catch (Exception e)
        {
            // TODO implement transient IO error resilience policy
            _logger.LogError("Error message: {Message}", e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetOrders(cancellationToken);
        }
        catch (Exception e)
        {
            // TODO implement transient IO error resilience policy
            _logger.LogError("Error message: {Message}", e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Payment>> GetCosts(int paymentCategoryId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _repository.GetCostsByCategory(paymentCategoryId, cancellationToken);
        }
        catch (Exception e)
        {
            // TODO implement transient IO error resilience policy
            _logger.LogError("Error message: {Message}", e.Message);
            throw;
        }
    }
}