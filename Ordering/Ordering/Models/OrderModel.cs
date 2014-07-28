using Ordering.Enums;
using System.Collections.Generic;

namespace Ordering.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public IList<Ef.Product> ProductList { get; set; }
        public StatusEnum Status { get; set; }
        public bool IsAdmin { get; set; }
    }
}