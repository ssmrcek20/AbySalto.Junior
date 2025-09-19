using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly IApplicationDbContext _context;
        public OrderRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync(bool sortByTotal)
        {
            var query = _context.Orders.AsQueryable();
            if (sortByTotal)
                query = query.OrderByDescending(o => o.TotalAmount);
            return await query.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
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
