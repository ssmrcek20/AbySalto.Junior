using AbySalto.Junior.Models;

namespace AbySalto.Junior.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync(bool sortByTotal);
        Task<Order?> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task SaveChangesAsync();
    }
}
