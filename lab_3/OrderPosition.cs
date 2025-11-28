using System;

namespace Lab3
{
    public class OrderPosition
    {
        public MarketProduct Product { get; set; }
        public int Count { get; set; }
        public float CookTime { get; set; }
        public float Cost { get; set; }

        public OrderPosition(MarketProduct product, int count)
        {
            Count = count;
            Product = product;
            CookTime = GetCookTime();
            Cost = GetCost();
        }

        public float GetCookTime()
        {
            if (Product is MarketDish dish) // страшный зверь
            {
                return dish.CookTime * Count;
            }
            return 0f;
        }

        public float GetCost()
        {
            return Product.Cost*Count;
        }

    }
}