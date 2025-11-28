using System;

namespace Lab3
{
    public class MarketDish : MarketProduct
    {
        public float CookTime { get; protected set; }

        public MarketDish(int id, string name, float cost, float weight, float cooktime) 
        : base(id, name, cost, weight)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Weight = weight;
            CookTime = cooktime;
        }
    }

}