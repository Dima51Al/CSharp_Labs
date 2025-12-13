using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Player
    {
        private Dictionary<PotionType, int> ActivePotionBonuses = new();
        
        public int BaseDamage { get; private set; } = 1;
        public int BaseLuck { get; private set; } = 1;
        public int BaseSpeed { get; private set; } = 20;
        public int BaseDefense { get; private set; } = 4;

        public void ApplyPotion(Potion potion)
        {
            if (!Inventory.Items.Contains(potion))
            {
                Console.WriteLine($"{potion.Name} нет в инвентаре.");
                return;
            }

            if (ActivePotionBonuses.ContainsKey(potion.Type))
            {
                int oldBonus = ActivePotionBonuses[potion.Type];
                RemovePotionBonus(potion.Type, oldBonus);
            }

            int bonus = potion.GetBonus(this);
            ActivePotionBonuses[potion.Type] = bonus;
            ApplyPotionBonus(potion.Type, bonus);
            Inventory.RemoveItem(potion);
            Console.WriteLine($"{potion.Name} применён, бонус {bonus}! Зелье удалено из инвентаря.");
        }

        private void ApplyPotionBonus(PotionType type, int bonus)
        {
            switch (type)
            {
                case PotionType.Damage: BaseDamage += bonus; break;
                case PotionType.Luck: BaseLuck += bonus; break;
                case PotionType.Speed: BaseSpeed += bonus; break;
                case PotionType.Defense: BaseDefense += bonus; break;
            }
        }

        private void RemovePotionBonus(PotionType type, int bonus)
        {
            switch (type)
            {
                case PotionType.Damage: BaseDamage -= bonus; break;
                case PotionType.Luck: BaseLuck -= bonus; break;
                case PotionType.Speed: BaseSpeed -= bonus; break;
                case PotionType.Defense: BaseDefense -= bonus; break;
            }
        }

        private int damageBuff = 0;
        private int luckBuff = 0;
        private int speedBuff = 0;
        private int defenseBuff = 0;

        public Weapon? EquippedWeapon { get; set; } = null;
        public Dictionary<ArmorType, Armor?> EquippedArmor { get; private set; }


        public IInventory Inventory { get; private set; }

        public Player(IInventory inventory)
        {
            Inventory = inventory;
            
            EquippedArmor = new Dictionary<ArmorType, Armor?>()
            {
                { ArmorType.Head, null },
                { ArmorType.Chest, null },
                { ArmorType.Legs, null },
                { ArmorType.Feet, null }
            };
        }

        public void AddBuff(string stat, int value)
        {
            switch (stat)
            {
                case "Damage": damageBuff += value; break;
                case "Luck": luckBuff += value; break;
                case "Speed": speedBuff += value; break;
                case "Defense": defenseBuff += value; break;
            }
        }

        public int GetDamage() => BaseDamage + (EquippedWeapon?.Damage ?? 0) + damageBuff;

        public int GetLuck()
        {
            int bonus = 0;
            foreach (var armor in EquippedArmor.Values)
                if (armor != null) bonus += armor.Luck;
            return BaseLuck + bonus;
        }

        public int GetSpeed()
        {
            int bonus = 0;
            foreach (var armor in EquippedArmor.Values)
                if (armor != null) bonus += armor.Speed;
            return BaseSpeed + bonus;
        }

        public int GetDefense()
        {
            int bonus = 0;
            foreach (var armor in EquippedArmor.Values)
                if (armor != null) bonus += armor.Defense;
            return BaseDefense + bonus + defenseBuff;
        }

        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }

        public void UnEquipWeapon(Weapon weapon)
        {
            if (EquippedWeapon == weapon) EquippedWeapon = null;
        }

        public void EquipArmor(Armor armor)
        {
            EquippedArmor[armor.Type] = armor;
        }

        public void UnEquipArmor(Armor armor)
        {
            if (EquippedArmor[armor.Type] == armor) EquippedArmor[armor.Type] = null;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("=== Надето ===");
            Console.WriteLine($"Оружие: {(EquippedWeapon != null ? EquippedWeapon.Name + $" (урон {EquippedWeapon.Damage})" : "нет")}");

            foreach (var slot in EquippedArmor.Keys)
            {
                var armor = EquippedArmor[slot];
                string desc = armor != null ? $"{armor.Name} (защита {armor.Defense})" : "нет";
                Console.WriteLine($"{slot}: {desc}");
            }

            Console.WriteLine("\n=== Характеристики ===");
            Console.WriteLine($"Урон: База {BaseDamage} + Бафф {damageBuff + (EquippedWeapon?.Damage ?? 0)} = {GetDamage()}");
            Console.WriteLine($"Удача: База {BaseLuck} + Бафф {GetLuck() - BaseLuck} = {GetLuck()}");
            Console.WriteLine($"Скорость: База {BaseSpeed} + Бафф {GetSpeed() - BaseSpeed} = {GetSpeed()}");
            Console.WriteLine($"Защита: База {BaseDefense} + Бафф {GetDefense() - BaseDefense} = {GetDefense()}");

            Console.WriteLine("\n=== В инвентаре ===");
            if (Inventory.Items.Count == 0) 
                Console.WriteLine("Инвентарь пуст");
            else
            {
                foreach (var item in Inventory.Items)
                {
                    string type = item switch
                    {
                        Weapon => "Оружие",
                        Armor => "Броня",
                        Potion => "Зелье",
                        QuestItem => "Квестовый предмет",
                        _ => "Предмет"
                    };
                    Console.WriteLine($"{item.Name} ({type})");
                }
            }
            Console.WriteLine("=====================\n");
        }
    }
}