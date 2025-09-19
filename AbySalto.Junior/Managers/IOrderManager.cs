using AbySalto.Junior.Models;

namespace AbySalto.Junior.Managers
{
    public interface IOrderManager
    {
        Task<int> CreateOrderAsync(Order order);
    }
}
