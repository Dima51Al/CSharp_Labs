
using System;

namespace Lab3
{
    public interface IOrderObserver
    {
        void OnOrderStatusChanged(Order order, int oldStatus, int newStatus);
        void OnOrderPaid(Order order);
        void OnOrderDelivered(Order order);
    }
}
