
using System;

namespace Lab3
{

    public class PreparingState : IOrderState
    {
        public int StatusCode => 1;

        public bool ProcessNextStep(Order order)
        {
            float timeCook = order.GetOrderCookTime();
            Console.WriteLine($"Статус сборки. примерно {(int)timeCook / 60 + 1} минут");
            order.SetDeliveryStatusInternal(2);
            return true;
        }
    }

}

