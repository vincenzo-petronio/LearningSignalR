using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace RealTimeEvents.Server
{
    public class EventsHub : Hub
    {
        // I metodi servono per essere invocati dai client.
        // In una logica di comunicazione server -> client, non sono necessari.

        //public async Task SendBroadcastEvent(string message, int messageId)
        //{
        //    await Clients.All.SendAsync($"{1} - {0}", message, messageId);
        //}

        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("OnEventListener", $"Socket opened");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("OnEventListener", $"Socket closed");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
