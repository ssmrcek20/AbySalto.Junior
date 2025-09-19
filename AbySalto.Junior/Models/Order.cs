using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string CustomerName { get; set; }

        [Required, EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

        [Required, StringLength(50)]
        public required string PaymentMethod { get; set; }

        [Required, StringLength(250)]
        public required string DeliveryAddress { get; set; }

        [Required, Phone]
        public required string ContactNumber { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(5)]
        public required string Currency { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
