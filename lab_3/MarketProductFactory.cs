using System;

namespace Lab3
{
    class MarketProductFactory : IMarketProductFactory
    {
        public MarketProduct Create(
            int id,
            string name,
            float cost,
            float weight,
            float? cooktime = null)
        {

            if (cooktime.HasValue)
            {
                return new MarketDish(
                    id,
                    name,
                    cost,
                    weight,
                    cooktime.Value);
            }
            else
            {
                return new MarketProduct(
                    id,
                    name,
                    cost,
                    weight);
            }
        }
    }
}