using Microsoft.AspNetCore.SignalR;

namespace HospitalDashboard.API.Hubs
{
    public class ResourceHub : Hub
    {
        public async Task BroadcastChange(string message)
        {
            await Clients.All.SendAsync("ReceiveUpdate", message);
        }
    }
}
