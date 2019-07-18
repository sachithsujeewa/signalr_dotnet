using SignalRCoffeeShop.Models;
using System.Web.Http;

namespace SignalRCoffeeShop.Controllers
{
    public class CoffeeController : ApiController
    {
        public static int OrderId { get; set; }

        [HttpPost]
        public int OrderCoffee(Order order)
        {
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<CoffeeHub>();
            //hubContext.Clients.All.NewOrder(order);
            OrderId++;
            return OrderId;
        }
    }
}