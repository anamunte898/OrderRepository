using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Ef
{
    public class OrderRepository
    {
        public OrderingEntities OrderEntites { get; set; }

        public OrderRepository()
        {
            OrderEntites = new OrderingEntities();
        }
        public IList<Order> GetAllOrders()
        {
            return OrderEntites.Orders.ToList();
        }
        public IList<Product> GetAllProducts()
        {
            return OrderEntites.Products.ToList();
        }

        public void AddOrder(Order order)
        {
            OrderEntites.Orders.Add(order);
            OrderEntites.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            OrderEntites.Orders.Remove(order);
            OrderEntites.SaveChanges();
        }

        public void EditOrder(Order order)
        {
            OrderEntites.Orders.AddOrUpdate(order);
            OrderEntites.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return OrderEntites.Orders.Single(p => p.Id == id);
        }
        public Product GetProductById(int id)
        {
            return OrderEntites.Products.Single(p => p.Id == id);
        }
        public User GetUserByUsername(string username)
        {
            return OrderEntites.Users.FirstOrDefault(p => p.UserName == username);
        }

    }
}
