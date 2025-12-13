using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Order
    {
        private List<OrderPosition> positions = new List<OrderPosition>();
        private List<IOrderObserver> observers = new List<IOrderObserver>();

        public User OrderUser { get; private set; }
        public IDelivery OrderDelivery { get; private set; }
        public bool PaidStatus { get; private set; } = false;
        private int _deliveryStatus = 0;
        public int DeliveryStatus
        {
            get => _deliveryStatus;
            private set
            {
                int old = _deliveryStatus;
                _deliveryStatus = value;
                NotifyStatusChanged(old, value);
            }
        }
        private IPricingStrategy _pricingStrategy;

        public IReadOnlyList<OrderPosition> Positions => positions.AsReadOnly();

        public Order(User user, IDelivery delivery)
        {
            OrderUser = user;
            OrderDelivery = delivery;
        }

        private void NotifyStatusChanged(int oldStatus, int newStatus)
        {
            foreach (var observer in observers)
                observer.OnOrderStatusChanged(this, oldStatus, newStatus);
        }

        private void NotifyPaid()
        {
            foreach (var observer in observers)
                observer.OnOrderPaid(this);
        }

        private void NotifyDelivered()
        {
            foreach (var observer in observers)
                observer.OnOrderDelivered(this);
        }

        public void Subscribe(IOrderObserver observer) => observers.Add(observer);
        public void Unsubscribe(IOrderObserver observer) => observers.Remove(observer);



        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            _pricingStrategy = strategy;
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
            if (status >= 0 && status <= 4)
                DeliveryStatus = status;
        }

        public float GetOrderCookTime()
        {
            float time = 0;
            foreach (var item in positions)
                time += item.GetCookTime();
            return time;
        }

        public float GetOrderDeliveryCost()
        {
            return OrderDelivery.GetDeliveryCost();
        }

        public float GetOrderCost()
        {
            if (_pricingStrategy == null)
                throw new InvalidOperationException("Pricing strategy not set");
            return _pricingStrategy.CalculateCost(this);
        }

        public float GetOrderDeliveryTime()
        {
            return GetOrderCookTime() + OrderDelivery.GetDeliveryTime();
        }

        public bool PayOrder()
        {
            float orderCost = GetOrderCost();
            if (orderCost <= OrderUser.Balance)
            {
                OrderUser.ReduceBalance(orderCost);
                PaidStatus = true;
                NotifyPaid();
                return true;
            }
            return false;
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
                NotifyDelivered();
                return true;
            }
            return false;
        }
    }
}
