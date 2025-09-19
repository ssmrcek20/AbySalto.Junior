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

        /// <summary>
        /// Get all orders. Optionally sorted by total price.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] bool sortByTotal = false)
        {
            try
            {
                var orders = await _orderManager.GetOrdersAsync(sortByTotal);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders.");
                return StatusCode(500, new { message = "An error occurred while getting orders." });
            }
        }

        /// <summary>
        /// Get order by ID.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            try
            {
                var order = await _orderManager.GetOrderByIdAsync(id);
                if (order == null)
                    return NotFound(new { message = "Order not found." });
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order by id.");
                return StatusCode(500, new { message = "An error occurred while getting the order." });
            }
        }

        /// <summary>
        /// Create new order with items.
        /// </summary>
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

        /// <summary>
        /// Update order status.
        /// </summary>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> ChangeStatusOfOrder([FromRoute] int id, [FromBody] OrderStatus status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!Enum.IsDefined(typeof(OrderStatus), status))
                return BadRequest(new { message = "Invalid status value." });

            try
            {
                var updated = await _orderManager.ChangeStatusOfOrderAsync(id, status);
                if (!updated)
                    return NotFound(new { message = "Order not found." });
                return Ok(new { message = "Status changed successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing status of order.");
                return StatusCode(500, new { message = "An error occurred while changing status of order." });
            }
        }
    }
}
