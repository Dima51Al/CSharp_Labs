using System;

namespace Lab3
{
    public class StandardPricing : IPricingStrategy
    {
        public float CalculateCost(Order order)
        {
            float cost = 0;
            foreach (var item in order.Positions)
                cost += item.GetCost();


            FinanceManipulation fm = new FinanceManipulation();
            cost *= fm.GetMarja();

            cost *= order.OrderUser.GetDiscount();

            cost += order.OrderDelivery.GetDeliveryCost();

            return cost;
        }
    }
}