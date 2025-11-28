using System;

namespace Lab2
{
    public class Armor : Item
{
    public int Defense { get; private set; }
    public int Luck { get; private set; }
    public int Speed { get; private set; }
    public ArmorType Type { get; private set; }
    public int Level { get; private set; }

    public Armor(string name, int baseValue, ArmorType type, int level = 1)
        : base(name, weight: 1) // вес 1 по умолчанию
    {
        Type = type;
        Level = level;
        switch (type)
        {
            case ArmorType.Head:
                Luck = baseValue;
                Speed = 0;
                Defense = 0;
                break;
            case ArmorType.Chest:
                Defense = baseValue;
                Luck = 0;
                Speed = 0;
                break;
            case ArmorType.Legs:
                Luck = baseValue / 2;
                Speed = baseValue / 2;
                Defense = 0;
                break;
            case ArmorType.Feet:
                Speed = baseValue;
                Luck = 0;
                Defense = 0;
                break;
        }
    }

    public Armor Clone()
    {
        return new Armor(Name, Level, Type, Level);
    }

    public override void Accept(IUseBehavior behavior, Player player)
    {
        behavior.Use(this, player);
    }
}

}
