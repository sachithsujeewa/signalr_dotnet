using SignalRCoffeeShop.Models;
using System.Threading.Tasks;

namespace SignalRCoffeeShop.Hubs
{
    public interface ICoffeeClient
    {
        Task NewOrder(Order order);
        Task ReceiveOrderUpdate(UpdateInfo info);
        Task Finished(Order order);
    }
}
