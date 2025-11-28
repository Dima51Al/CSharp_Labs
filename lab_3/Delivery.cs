using System;

namespace Lab3
{
    public class Delivery
    {

        public float R { get; private set; }
        public Delivery(float rasstoianie)
        {
            R = rasstoianie;
        }

        public float GetDeliveryCost()
        {
            return R * 100; //100рублей за км
        }
        public float GetDeliveryTime()
        {
            return R * 200; //100рублей за км
        }
    }
}
