
using System;

namespace Lab3
{

    public class PreparingState : IOrderState
    {
        public int StatusCode => 1;

        public bool ProcessNextStep(Order order)
        {
            float timeCook = order.GetOrderCookTime();
            Console.WriteLine($"Сброка, осталось +- {(int)timeCook / 60 + 1} минут(ы)");
            order.SetDeliveryStatusInternal(2);
            return true;
        }
    }

}

