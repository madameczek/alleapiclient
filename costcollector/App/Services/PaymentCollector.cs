using costcollector.App.Entities;
using costcollector.App.Interfaces;

namespace costcollector.App.Services;

public class PaymentCollector : IPaymentCollector
{
    private readonly IPaymentRepository _repository;

    public PaymentCollector(IPaymentRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<Payment>> GetPayments(Guid orderId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}