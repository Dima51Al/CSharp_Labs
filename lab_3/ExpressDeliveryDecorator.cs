
using System;

namespace Lab3
{
    public class ExpressDeliveryDecorator : DeliveryDecorator
    {
        // дороже но быстрее
        public ExpressDeliveryDecorator(IDelivery delivery) : base(delivery) { }

        public override float GetDeliveryCost() => base.GetDeliveryCost() * 1.5f; 
        public override float GetDeliveryTime() => base.GetDeliveryTime() * 0.7f;
    }
}
