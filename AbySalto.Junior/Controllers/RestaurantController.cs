using AbySalto.Junior.Managers;
using AbySalto.Junior.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly ILogger<RestaurantController> _logger;
        public RestaurantController(IOrderManager orderManager, ILogger<RestaurantController> logger)
        {
            _orderManager = orderManager;
            _logger=logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int orderId = await _orderManager.CreateOrderAsync(order);
                return StatusCode(201, new { id = orderId, message = "Order created successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order.");
                return StatusCode(500, new { message = "An error occurred while placing the order." });
            }
        }
    }
}
