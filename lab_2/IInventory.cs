using System.Collections.Generic;

namespace Lab2
{
    public interface IInventory
    {
        float MaxWeight { get; }
        IReadOnlyList<Item> Items { get; }

        void AddItem(Item item);
        void RemoveItem(Item item);
        float CurrentWeight();
    }
}