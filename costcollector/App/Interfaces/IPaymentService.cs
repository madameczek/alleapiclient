using costcollector.App.Entities;

namespace costcollector.App.Interfaces;

public interface IPaymentService
{
    public Task SavePayment(Payment payment, CancellationToken cancellationToken = default);
    public Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default);
}