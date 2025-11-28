using System;
using Lab3;

namespace Lab3
{
    public class MarketPosition
    {
        public MarketProduct Product{ get; protected set; }
        public int Count { get; protected set; }


        public MarketPosition(MarketProduct product, int count)
        {
            Product = product;
            Count = count;
        }

    }
}
