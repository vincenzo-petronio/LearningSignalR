using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace RealTimeEvents.Server
{
    public class EventsHub : Hub
    {
        //public async Task SendBroadcastEvent(string message, int messageId)
        //{
        //    await Clients.All.SendAsync($"{1} - {0}", message, messageId);
        //}
    }
}
