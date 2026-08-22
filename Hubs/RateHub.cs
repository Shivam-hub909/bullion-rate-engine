using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BullionRateEngine.Hubs
{
    public class RateHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveSystemMessage", "Connected to Live Bullion Feed Engine.");
            await base.OnConnectedAsync();
        }
    }
}
