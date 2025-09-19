using AbySalto.Junior.Models;

namespace AbySalto.Junior.Managers
{
    public interface IOrderManager
    {
        Task<List<Order>> GetOrdersAsync(bool sortByTotal);
        Task<int> CreateOrderAsync(Order order);
    }
}
