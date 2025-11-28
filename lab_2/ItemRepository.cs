using System;
using System.Collections.Generic;

namespace Lab2
{
    public static class ItemRepository
    {
        public const int MaxLevel = 3;

        public static List<Item> AllItems { get; private set; } = new List<Item>()
        {

            new Weapon("Wooden Sword", 5, 4, 1),
            new Weapon("Stone Sword", 6, 5, 1),
            new Weapon("Iron Sword", 7, 6, 1),
            new Weapon("Golden Sword", 4, 4, 1),
            new Weapon("Diamond Sword", 8, 7, 1),
            new Weapon("Netherite Sword", 9, 8, 1),


            new Armor("Leather Helmet", 2, ArmorType.Head, 1),
            new Armor("Chainmail Helmet", 3, ArmorType.Head, 1),
            new Armor("Iron Helmet", 4, ArmorType.Head, 1),
            new Armor("Golden Helmet", 2, ArmorType.Head, 1),
            new Armor("Diamond Helmet", 5, ArmorType.Head, 1),
            new Armor("Netherite Helmet", 6, ArmorType.Head, 1),


            new Armor("Leather Chestplate", 5, ArmorType.Chest, 1),
            new Armor("Chainmail Chestplate", 6, ArmorType.Chest, 1),
            new Armor("Iron Chestplate", 7, ArmorType.Chest, 1),
            new Armor("Golden Chestplate", 5, ArmorType.Chest, 1),
            new Armor("Diamond Chestplate", 8, ArmorType.Chest, 1),
            new Armor("Netherite Chestplate", 9, ArmorType.Chest, 1),


            new Armor("Leather Leggings", 4, ArmorType.Legs, 1),
            new Armor("Chainmail Leggings", 5, ArmorType.Legs, 1),
            new Armor("Iron Leggings", 6, ArmorType.Legs, 1),
            new Armor("Golden Leggings", 4, ArmorType.Legs, 1),
            new Armor("Diamond Leggings", 7, ArmorType.Legs, 1),
            new Armor("Netherite Leggings", 8, ArmorType.Legs, 1),


            new Armor("Leather Boots", 1, ArmorType.Feet, 1),
            new Armor("Chainmail Boots", 2, ArmorType.Feet, 1),
            new Armor("Iron Boots", 3, ArmorType.Feet, 1),
            new Armor("Golden Boots", 1, ArmorType.Feet, 1),
            new Armor("Diamond Boots", 4, ArmorType.Feet, 1),
            new Armor("Netherite Boots", 5, ArmorType.Feet, 1),

            new Potion("Damage Potion", 1, PotionType.Damage),
            new Potion("Luck Potion", 1, PotionType.Luck),
            new Potion("Speed Potion", 1, PotionType.Speed),
            new Potion("Defense Potion", 1, PotionType.Defense),

            new QuestItem("Хвост ослика Иа")
        };

        public static Item? GetItemByName(string name)
        {
            return AllItems.Find(i => i.Name == name);
        }


        public static Item CreateItem(string name)
        {
            Item template = GetItemByName(name)
                            ?? throw new InvalidOperationException($"Item '{name}' не найден в репозитории.");

            return template switch
            {
                Weapon w => w.Clone(),
                Armor a => a.Clone(),
                Potion p => new Potion(p.Name, p.Weight, p.Type),
                QuestItem q => new QuestItem(q.Name),
                _ => throw new InvalidOperationException("Неизвестный тип предмета.")
            };
        }
    }
}