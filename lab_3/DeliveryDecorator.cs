using System;
namespace Lab3
{
    public abstract class DeliveryDecorator : IDelivery
    {
        private IDelivery _delivery { get; }

        public DeliveryDecorator(IDelivery delivery)
        {
            _delivery = delivery;
        }

        public virtual float GetDeliveryCost() => _delivery.GetDeliveryCost();
        public virtual float GetDeliveryTime() => _delivery.GetDeliveryTime();
    }
}
