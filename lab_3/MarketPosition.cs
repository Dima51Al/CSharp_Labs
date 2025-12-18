using System;
using Lab3;

namespace Lab3
{
    public class MarketPosition
    {
        public MarketProduct Product{ get; set; }
        public int Count { get;  set; }


        public MarketPosition(MarketProduct product, int count)
        {
            Product = product;
            Count = count;
        }

    }
}
