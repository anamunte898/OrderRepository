using Microsoft.AspNet.SignalR;

namespace Ordering.Hubs
{
    public class OrderHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}