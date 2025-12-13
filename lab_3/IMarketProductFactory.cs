using System;

namespace Lab3
{
    interface IMarketProductFactory
    {
        MarketProduct Create(
            int id,
            string name,
            float cost,
            float weight,
            float? cooktime = null
        );
    }
}
