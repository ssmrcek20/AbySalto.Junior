using AbySalto.Junior.Models;

namespace AbySalto.Junior.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync(bool sortByTotal);
        Task CreateOrderAsync(Order order);
        Task SaveChangesAsync();
    }
}
