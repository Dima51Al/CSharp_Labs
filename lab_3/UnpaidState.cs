
using System;

namespace Lab3
{

    public class UnpaidState : IOrderState
    {
        public int StatusCode => 0;

        public bool ProcessNextStep(Order order)
        {
            if (order.PayOrder())
            {
                order.SetDeliveryStatusInternal(1);
                return true;
            }
            return false;
        }
    }

}


