using costcollector.App.Entities;

namespace costcollector.App.Interfaces;

public interface IPaymentRepository
{
    public Task SavePayment(Payment payment, CancellationToken cancellationToken = default);
    public Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default);
    public Task<IEnumerable<Payment>> GetCostsByCategory(int paymentCategoryId,
        CancellationToken cancellationToken = default);
}