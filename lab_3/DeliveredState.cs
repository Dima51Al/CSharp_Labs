
using System;

namespace Lab3
{

    public class DeliveredState : IOrderState
    {
        public int StatusCode => 3;

        public bool ProcessNextStep(Order order)
        {
            Console.WriteLine($"Заказ Доставлен");
            order.SetDeliveryStatusInternal(4);
            order.NotifyDelivered();
            return true;
        }
    }

}
