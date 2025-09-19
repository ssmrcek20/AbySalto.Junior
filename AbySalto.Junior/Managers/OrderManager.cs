using AbySalto.Junior.Models;
using AbySalto.Junior.Repositories;

namespace AbySalto.Junior.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> CreateOrderAsync(Order order)
        {
            order.TotalAmount = order.Items.Sum(i => i.Price * i.Quantity);

            await _orderRepository.CreateOrderAsync(order);
            await _orderRepository.SaveChangesAsync();
            return order.Id;
        }
    }
}
