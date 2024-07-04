using costcollector.App.Entities;

namespace costcollector.App.Interfaces;

public interface IPaymentCollector
{
    public Task<IEnumerable<Payment>> GetPayments(Guid orderId, CancellationToken cancellationToken = default);
}