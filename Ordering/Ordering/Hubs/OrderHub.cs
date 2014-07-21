using System;
using System.Collections.Generic;
using System.Security.Principal;
using Ef;
using Microsoft.AspNet.SignalR;
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
            var repository= new OrderRepository();
            repository.AddOrder(new Order()
            {
               ProductId=1,
               OrderDate = DateTime.Now,
               Status="New",
               UserId=1,
            });
            
            newOrder.Status = StatusEnum.New;
            Clients.All.orderCreated(newOrder);

        }

        public void GetAll()
        {
            //todo: get from database
            var orders = new List<OrderModel>();
            Clients.Caller.allOrdersRetrieved(orders);
        }
    }
}