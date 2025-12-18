using System;
namespace Lab2
{
    public class Inventory: IInventory
    {
        public float MaxWeight { get; set; }
        private readonly List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items;

        public Inventory(float maxWeight)
        {
            MaxWeight = maxWeight;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
            {
                if (item.IsQuest)
                {
                    Console.WriteLine($"Невозможно выбросить квестовый предмет: {item.Name}");
                    return;
                }
                _items.Remove(item);
            }

        public float CurrentWeight()
        {
            return _items.Sum(i => i.Weight);
        }
    }
}