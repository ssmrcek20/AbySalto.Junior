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

        public async Task<List<Order>> GetOrdersAsync(bool sortByTotal)
        {
            return await _orderRepository.GetOrdersAsync(sortByTotal);
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            order.TotalAmount = order.Items.Sum(i => i.Price * i.Quantity);

            await _orderRepository.CreateOrderAsync(order);
            await _orderRepository.SaveChangesAsync();
            return order.Id;
        }

        public async Task<bool> ChangeStatusOfOrderAsync(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                return false;

            order.Status = status;
            await _orderRepository.SaveChangesAsync();
            return true;
        }
    }
}
