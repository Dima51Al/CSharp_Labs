using System;

namespace Lab3
{
    public class Delivery
    {

        public float R { get; private set; }
        public float W { get; private set; }
        public Delivery(float rasstoianie, float weight)
        {
            R = rasstoianie;
            W = weight;
        }

        public float GetDeliveryCost()
        {
            return W*20 + R * 100; //100рублей за км
        }
        public float GetDeliveryTime()
        {
            return R * 200; //100рублей за км
        }


    }
}
