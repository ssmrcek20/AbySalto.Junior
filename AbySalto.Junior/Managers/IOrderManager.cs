using AbySalto.Junior.Models;

namespace AbySalto.Junior.Managers
{
    public interface IOrderManager
    {
        Task<List<Order>> GetOrdersAsync(bool sortByTotal);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(Order order);
    }
}
