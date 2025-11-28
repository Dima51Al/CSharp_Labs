using System;
using Lab2;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(50);

            Weapon sword1 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
            Weapon sword2 = (Weapon)ItemRepository.CreateItem("Wooden Sword");

            Armor helmet = (Armor)ItemRepository.CreateItem("Leather Helmet");
            Armor chest = (Armor)ItemRepository.CreateItem("Leather Chestplate");

            Potion damagePotion = (Potion)ItemRepository.CreateItem("Damage Potion");
            Potion speedPotion = (Potion)ItemRepository.CreateItem("Speed Potion");

            QuestItem donkeyTail = (QuestItem)ItemRepository.CreateItem("Хвост ослика Иа");

            player.Inventory.AddItem(sword1);
            player.Inventory.AddItem(sword2);
            player.Inventory.AddItem(helmet);
            player.Inventory.AddItem(chest);
            player.Inventory.AddItem(damagePotion);
            player.Inventory.AddItem(speedPotion);
            player.Inventory.AddItem(donkeyTail);

            player.EquipWeapon(sword1);
            player.EquipArmor(helmet);
            player.EquipArmor(chest);

            player.ApplyPotion(damagePotion);
            player.ApplyPotion(speedPotion);

            sword1.LevelUp(player, sword2);

            player.DisplayInventory();
            

            player.UnEquipWeapon(sword1);
            player.UnEquipArmor(helmet);
            player.UnEquipArmor(chest);


            player.DisplayInventory();
        }
    }
}
