using System;

namespace Lab3
{
     public class Market
    {
        // Словарь: ключ = продукт, значение = количество
        private Dictionary<MarketProduct, int> positions = new Dictionary<MarketProduct, int>();

        public Market(){}

        public void AddProduct(MarketProduct product, int count)
        {
            if (positions.ContainsKey(product))
                positions[product] += count; 
            else
                positions[product] = count;
        }


        public int GetCountByID(int id)
        {
            foreach (var pos in positions)
            {
                if (pos.Key.Id == id)
                    return pos.Value;
            }
            return 0;
        }


        public void PrintAllPositions()
        {
            foreach (var pos in positions)
            {
                Console.WriteLine($"ID: {pos.Key.Id}, Name: {pos.Key.Name}, Count: {pos.Value}");
            }
        }
    }
}