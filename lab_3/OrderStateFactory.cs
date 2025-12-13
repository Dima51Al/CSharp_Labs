
using System;

namespace Lab3
{
    public static class OrderStateFactory
    {
        public static IOrderState CreateState(int statusCode)
        {
            return statusCode switch
            {
                0 => new UnpaidState(),
                1 => new PreparingState(),
                2 => new OnTheWayState(),
                3 => new DeliveredState(),
                4 => new CompletedState(),
                _ => throw new ArgumentException("Invalid status code")
            };
        }
    }
}
