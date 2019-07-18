using SignalRCoffeeShop.Models;
using System;
using System.Collections.Generic;

namespace SignalRCoffeeShop.Helpers
{
    public class OrderChecker
    {
        private readonly Random _random;
        private readonly string[] _status = { "Grinding beans", "Stemming milk", "Taking a sip (quality control)" };
        private readonly Dictionary<int, int> _statusTracker = new Dictionary<int, int>();

        public OrderChecker(Random random)
        {
            this._random = random;
        }

        private int GetNextStatusIndex(int orderNo)
        {
            if (!_statusTracker.ContainsKey(orderNo))
            {
                _statusTracker.Add(orderNo, -1);
            }
            _statusTracker[orderNo]++;
            return _statusTracker[orderNo];
        }

        public UpdateInfo GetUpdate(Order order)
        {
            if (_random.Next(1, 5) != 4)
            {
                return new UpdateInfo { New = false };
            }

            var index = GetNextStatusIndex(order.Id);

            if (_status.Length <= index)
            {
                return new UpdateInfo { New = false };
            }

            return new UpdateInfo
            {
                OrderId = order.Id,
                New = true,
                Update = _status[index],
                Finished = _status.Length - 1 == index
            };
        }
    }
}