using System;

namespace Lab3
{
    public class PromoPricing : IPricingStrategy
    {
        private float promoRate;

        public PromoPricing(float promoRate = 0.9f)
        {
            this.promoRate = promoRate;
        }

        public float CalculateCost(Order order)
        {
            float cost = 0;
            foreach (var item in order.Positions)
                cost += item.GetCost();

            FinanceManipulation fm = new FinanceManipulation();
            cost *= fm.GetMarja();


            cost *= promoRate;


            cost += order.OrderDelivery.GetDeliveryCost();

            return cost;
        }
    }
}