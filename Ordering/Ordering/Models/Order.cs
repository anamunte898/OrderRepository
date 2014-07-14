using Ordering.Enums;

namespace Ordering.Models
{
    public class Order
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public StatusEnum Status { get; set; }
    }
}