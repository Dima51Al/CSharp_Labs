using System;

namespace Lab3
{
    public class MarketProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Weight { get; set; }

        public MarketProduct(int id, string name, float cost, float weight)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        public override bool Equals(object? obj)
        {
            if (obj is MarketProduct other)
                return Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        

    }

}
