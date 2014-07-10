using System.Collections;
using System.Collections.Generic;

namespace Ordering.Models
{
    public class OrderModel
    {
        public IList<Order> OrderList { get; set; }
        public bool IsAdmin { get; set; }
    }
}