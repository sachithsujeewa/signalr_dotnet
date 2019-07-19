using Microsoft.AspNet.SignalR;
using SignalRCoffeeShop.Helpers;
using SignalRCoffeeShop.Models;
using System;
using System.Threading.Tasks;

namespace SignalRCoffeeShop.Hubs
{
    //[Authorize]
    public class CoffeeHub : Hub<ICoffeeClient>
    {
        private static readonly OrderChecker OrderChecker = new OrderChecker(new Random());

        public async Task GetUpdateForOrder(Order order)
        {
            await Clients.Others.NewOrder(order);

            UpdateInfo result;
            do
            {
                result = OrderChecker.GetUpdate(order);
                await Task.Delay(700);
                if (!result.New)
                {
                    continue;
                }

                await Clients.Caller.ReceiveOrderUpdate(result);
                await Clients.Group("allUpdateReceivers").ReceiveOrderUpdate(result);

            } while (!result.Finished);

            await Clients.Caller.Finished(order);
        }

        public override Task OnConnected()
        {
            if (Context.QueryString["group"] == "allUpdates")
            {
                Groups.Add(Context.ConnectionId, "allUpdateReceivers");
            }
            return base.OnConnected();
        }
    }
}