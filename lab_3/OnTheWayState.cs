
using System;

namespace Lab3
{
    public class OnTheWayState : IOrderState
    {
        public int StatusCode => 2;

        public bool ProcessNextStep(Order order)
        {
            float deliverTime = order.GetOrderDeliveryTime();
            Console.WriteLine($"Заказ прибудет примерно через {(int)deliverTime / 60 + 1} минут");
            order.SetDeliveryStatusInternal(3);
            return true;
        }
    }

}
