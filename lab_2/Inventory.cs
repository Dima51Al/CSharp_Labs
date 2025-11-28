using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public class Inventory
    {
        public float MaxWeight { get; set; }
        private List<Item> items = new List<Item>();

        public Inventory(float maxWeight)
        {
            MaxWeight = maxWeight;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
            {
                if (item.Is_quest)
                {
                    Console.WriteLine($"Невозможно выбросить квестовый предмет: {item.Name}");
                    return;
                }
                Items.Remove(item);
            }

        public float CurrentWeight()
        {
            return items.Sum(i => i.Weight);
        }

        public List<Item> Items => items;
    }
}