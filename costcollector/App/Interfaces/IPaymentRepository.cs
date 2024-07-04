using costcollector.App.Entities;

namespace costcollector.App.Interfaces;

public interface IPaymentRepository
{
    public Task SavePayment(Payment payment, CancellationToken cancellationToken = default);
}