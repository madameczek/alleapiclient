using costcollector.App.Entities;
using costcollector.App.Interfaces;
using costcollector.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace costcollector.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly OrdersDbContext _dbContext;

    public PaymentRepository(OrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SavePayment(Payment payment, CancellationToken cancellationToken)
    {
        var dbPayment = _dbContext.Payments.FirstOrDefault(p => p.AllegroId == payment.AllegroId);
        payment.PaymentTypeId = payment.Type.Id;
        payment.Type = null;
        if (dbPayment is null)
            _dbContext.Add(payment);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders.ToListAsync(cancellationToken: cancellationToken);
    }
}