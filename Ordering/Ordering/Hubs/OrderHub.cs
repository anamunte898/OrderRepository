using System.Security.Principal;
using Microsoft.AspNet.SignalR;
using Ordering.Enums;
using Ordering.Models;

namespace Ordering.Hubs
{
    public class OrderHub : Hub
    {
        public void RequestOrder(string message)
        {
            var userName = WindowsIdentity.GetCurrent().Name;
            Groups.Add(Context.ConnectionId, "admin");
            Clients.All.addNewMessageToPage(userName, message);
        }

        public void SendOrder(string productName,double price)
        {
            var windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                var userName = windowsIdentity.Name;
                var order = new Order()
                {
                    Price = price,
                    ProductName = productName,
                    Status = StatusEnum.New
                };
                Clients.Group("admin").addOrder(order);
            }
        }
    }
}