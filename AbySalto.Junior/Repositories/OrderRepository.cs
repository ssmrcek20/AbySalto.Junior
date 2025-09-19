using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly IApplicationDbContext _context;
        public OrderRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
