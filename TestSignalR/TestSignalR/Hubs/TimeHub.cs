using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace TestSignalR.Hubs
{
    public class TimeHub : Hub
    {
        private static int HoursDiff = 0;

        public void Connect ()
        {
            Clients.Caller.onConnected(DateTimeOffset.Now.AddHours(HoursDiff).ToUnixTimeMilliseconds());
        }

        public void ChangeServHours(int hours)
        {
            try
            {
                HoursDiff += hours;
                Clients.All.changeTime(DateTimeOffset.Now.AddHours(HoursDiff).ToUnixTimeMilliseconds());
            }
            catch(Exception e)
            {
                HoursDiff -= hours;
                Clients.Caller.errorMessage(e.Message);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}