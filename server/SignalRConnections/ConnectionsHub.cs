using Microsoft.AspNetCore.SignalR;

namespace SignalRConnections
{
    public class ConnectionsHub : Hub
    {
        private static List<string> _connections = new List<string>();
        public async Task GetConnections()
        {
            await Clients.All.SendAsync("GetConnections", _connections);
        }
        public override async Task OnConnectedAsync()
        {
            _connections.Add(Context.ConnectionId);
            await GetConnections();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _connections.Remove(Context.ConnectionId);
            await GetConnections();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
