using System;

namespace Lab2
{
    public class PotionUseBehavior : IUseBehavior
{
    public PotionType Type { get; private set; }

    public PotionUseBehavior(PotionType type)
    {
        Type = type;
    }

    public void Use(Item item, Player player)
    {
        if (item is Potion potion)
        {
            {
            player.ApplyPotion(potion);
            }
        }
    }
}

}