using costcollector.App.Entities;

namespace costcollector.App.Interfaces;

public interface IAllegroService
{
    public Task<IEnumerable<Payment>> FetchPayments(Guid orderId, CancellationToken cancellationToken = default);
}