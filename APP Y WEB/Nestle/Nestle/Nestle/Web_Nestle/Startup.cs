using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Web_Nestle.Startup))]

namespace Web_Nestle
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Para obtener más información acerca de cómo configurar su aplicación, visite http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
            //app.MapSignalR("/~/signalr", new HubConfiguration());
        }
    }
}
