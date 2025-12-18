
using System;

namespace Lab3
{
    public class LoggerObserver : IOrderObserver
    {
        public void OnOrderStatusChanged(Order order, int oldStatus, int newStatus)
        {
            Console.WriteLine($"[LOG] Статус заказа изменился: {oldStatus} → {newStatus}");
        }

        public void OnOrderPaid(Order order)
        {
            Console.WriteLine($"[LOG] Заказ оплачен. Сумма: {order.GetOrderCost()}");
        }

        public void OnOrderDelivered(Order order)
        {
            Console.WriteLine($"[LOG] Заказ доставлен пользователю: {order.OrderUser.Name}");
        }
    }
}

