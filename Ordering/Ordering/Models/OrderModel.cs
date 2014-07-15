using Ordering.Enums;

namespace Ordering.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public StatusEnum Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}