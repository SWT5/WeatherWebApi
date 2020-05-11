using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Hubs
{
    public class Updates:Hub
    {
        public async Task SendMsg(string msg)
        {
            await Clients.All.SendAsync("SendMsg", msg);
        }
    }
}
