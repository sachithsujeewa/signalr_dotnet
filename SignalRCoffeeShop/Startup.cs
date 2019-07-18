using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRCoffeeShop.Startup))]

namespace SignalRCoffeeShop
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //app.MapSignalR<CoffeeConnection>("/coffee");
        }
    }
}
