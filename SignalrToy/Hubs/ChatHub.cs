using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalrToy.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string nick, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", nick, message);
        }
    }
}