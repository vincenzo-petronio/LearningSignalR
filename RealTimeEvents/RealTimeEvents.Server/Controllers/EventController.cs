using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace RealTimeEvents.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IHubContext<EventsHub> hubContext;

        public EventController(IHubContext<EventsHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await hubContext.Clients.All.SendAsync("OnEventListener", "hello world!");
            return Ok();
        }
    }
}
