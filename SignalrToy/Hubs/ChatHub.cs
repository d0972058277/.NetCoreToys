using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalrToy.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Test");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Test");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageAsync(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}