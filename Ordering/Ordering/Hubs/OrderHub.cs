using System;
using System.Collections.Generic;
using System.Security.Principal;
using Ef;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Ordering.Enums;
using Ordering.Models;

namespace Ordering.Hubs
{
    public class OrderHub : Hub
    {
        public void RequestOrder(string message)
        {
            var windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                var userName = windowsIdentity.Name;
                Groups.Add(Context.ConnectionId, "admin");
                Clients.All.addNewMessageToPage(userName, message);
            }
        }

        public void AddOrder(OrderModel newOrder)
        {
            //todo add code for saving in the database
            var repository = new OrderRepository();
            var windowsIdentity = WindowsIdentity.GetCurrent();
            User user = null;
            if (windowsIdentity != null)
            {
                user = repository.GetUserByUsername(windowsIdentity.Name);
            }
            var order = new Order()
            {
                ProductId = 1,
                OrderDate = DateTime.Now,
                Status = "New",
                User = user,
            };
            repository.AddOrder(order);

            newOrder.Status = StatusEnum.New;
            newOrder.Id = order.Id;
            Clients.All.orderCreated(newOrder);

        }

        public void GetAll()
        {
            //todo: get from database
            var orders = new List<OrderModel>();
            Clients.Caller.allOrdersRetrieved(orders);
        }

        public void RemoveOrder(int deletedOrderId)
        {
            var repository = new OrderRepository();
            var order = repository.GetOrderById(deletedOrderId);
            repository.DeleteOrder(order);
            Clients.All.orderRemoved(deletedOrderId);
        }

        public void ProcessOrder(int deletedOrderId)
        {
            var repository = new OrderRepository();
            var order = repository.GetOrderById(deletedOrderId);
            order.Status = StatusEnum.Processed.ToString();
            repository.EditOrder(order);
          
            Clients.All.orderProcessed(order.Id);
        }
    }
}