using System;

namespace Lab3
{
    public class Order
    {
        private List<OrderPosition> positions = new List<OrderPosition>();
        public User OrderUser { get; private set; }
        public Delivery OrderDelivery { get; private set; }

        public bool PaidStatus { get; private set; } = false;

        public int DeliveryStatus { get; private set; } = 0; // 0 - не оплачен, 1 - сборка, 2 - у курьера, 3 - доставлен
        private float marja;


        public Order(User user, Delivery delivery)
        {
            OrderUser = user;
            OrderDelivery = delivery;
            
            FinanceManipulation marketMarja = new FinanceManipulation();
            marja = marketMarja.GetMarja();
        }

        public void AddPosition(OrderPosition position)
        {
            positions.Add(position);
        }
        public void RemovePosition(OrderPosition position)
        {
            positions.Remove(position);
        }

        public void SetDeliveryStatus(int status)
        {
            if (0 <= status && status <= 4)
            {
                DeliveryStatus = status;
            }
        }

        public float GetOrderCookTime()
        {
            float time = 0;
            foreach (var item in positions)
            {
                time += item.GetCookTime();
            }
            return time;
        }

        public float GetOrderDelivetyCost()
        {
            return OrderDelivery.GetDeliveryCost();

        }
        public float GetOrderCost()
        {
            float cost = 0;
            foreach (var item in positions)
            {
                cost += item.GetCost();
            }
            cost *= marja;
            cost *= OrderUser.GetDiscount();
            cost += OrderDelivery.GetDeliveryCost();

            return cost;

        }
        public float GetOrderDeliveryTime()
        {
            float time = GetOrderCookTime();
            time += OrderDelivery.GetDeliveryTime();
            return time;

        }

        public bool PayOrder()
        {
            float orderCost = GetOrderCost();
            if (orderCost <= OrderUser.Balance)
            {
                OrderUser.ReduceBalance(orderCost);
                PaidStatus = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeliveryNextStep()
        {
            if (DeliveryStatus == 0 && !PaidStatus)
            {
                if (PayOrder())
                {
                    SetDeliveryStatus(1);
                    return true;
                }
            }
            if (DeliveryStatus == 1)
            {
                float timeCook = GetOrderCookTime();
                Console.WriteLine($"Статус сборки. примерно {(int)timeCook / 60 + 1} минут");
                SetDeliveryStatus(2);
                return true;
            }
            if (DeliveryStatus == 2)
            {
                float deliverTime = GetOrderDeliveryTime();
                Console.WriteLine($"Заказ прибудет примерно через {(int)deliverTime / 60 + 1} минут");
                SetDeliveryStatus(3);
                return true;
            }
            if (DeliveryStatus == 3)
            {
                Console.WriteLine($"Заказ Доставлен");
                SetDeliveryStatus(4);
                return true;
            }
            return false;
        }
    }
}
    