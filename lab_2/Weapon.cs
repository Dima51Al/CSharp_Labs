using System;

namespace Lab2
{
    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public int Level { get; private set; }

        public Weapon(string name, float weight, int damage, int level = 1) : base(name, weight)
        {
            Damage = damage;
            Level = level;
        }

        public void LevelUp(Player player, Weapon match)
        {
            if (Level >= ItemRepository.MaxLevel)
            {
                Console.WriteLine($"{Name} уже достиг максимального уровня ({Level}).");
                return;
            }

            if (match.Name == Name && match != this && match.Level == Level && match != null)
            {
                Level++;
                Damage = (int)Math.Ceiling(Damage * 1.5);
                player.Inventory.RemoveItem(match);
                Console.WriteLine($"{Name} повысил уровень до {Level}, урон теперь {Damage}");
            }
            else
            {
                Console.WriteLine($"Нет второго {Name} уровня {Level} для повышения уровня.");
            }
        }

        public override void Accept(IUseBehavior behavior, Player player)
        {
            behavior.Use(this, player);
        }

        public Weapon Clone()
        {
            return new Weapon(Name, Weight, Damage, Level);
        }
    }
}
