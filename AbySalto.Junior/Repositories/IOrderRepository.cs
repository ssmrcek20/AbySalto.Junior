using AbySalto.Junior.Models;

namespace AbySalto.Junior.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task SaveChangesAsync();
    }
}
