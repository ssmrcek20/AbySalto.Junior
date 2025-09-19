using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AbySalto.Junior.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [Required, Range(1, 1000)]
        public int Quantity { get; set; }

        [Required, DataType(DataType.Currency), Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Required]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
