using System;


namespace Lab3
{
    
    public class Order
    {
        private List<OrderPosition> positions = new List<OrderPosition>();
        private List<IOrderObserver> observers = new List<IOrderObserver>();
        private IOrderState _currentState;

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
            _currentState = OrderStateFactory.CreateState(0);
        }

        public void NotifyStatusChanged(int oldStatus, int newStatus)
        {
            foreach (var observer in observers)
                observer.OnOrderStatusChanged(this, oldStatus, newStatus);
        }

        public void NotifyPaid()
        {
            foreach (var observer in observers)
                observer.OnOrderPaid(this);
        }

        public void NotifyDelivered()
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
                SetDeliveryStatusInternal(status);
        }

        public void SetDeliveryStatusInternal(int status)
        {
            var oldStatus = _currentState.StatusCode;
            _currentState = OrderStateFactory.CreateState(status);
            _deliveryStatus = status; 
            NotifyStatusChanged(oldStatus, status);
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
            return _currentState.ProcessNextStep(this);
        }
    }
}

