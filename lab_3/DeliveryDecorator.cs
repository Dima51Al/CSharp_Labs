using System;
namespace Lab3
{
    public abstract class DeliveryDecorator : IDelivery
{
    protected readonly IDelivery _delivery;

    public DeliveryDecorator(IDelivery delivery)
    {
        _delivery = delivery ?? throw new ArgumentNullException(nameof(delivery));
    }

    public virtual float GetDeliveryCost() => _delivery.GetDeliveryCost();
    public virtual float GetDeliveryTime() => _delivery.GetDeliveryTime();
}
}