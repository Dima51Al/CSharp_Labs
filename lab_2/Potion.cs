namespace Lab2
{
    public enum PotionType { Damage, Luck, Speed, Defense }

    public class Potion : Item
    {
        public PotionType Type { get; private set; }

        public Potion(string name, float weight, PotionType type) : base(name, weight)
        {
            Type = type;
        }

        public void Use(Player player)
        {
            IUseBehavior behavior = new PotionUseBehavior(Type);
            Accept(behavior, player);
        }

        public override void Accept(IUseBehavior behavior, Player player)
        {
            behavior.Use(this, player);
        }
        public int GetBonus(Player player)
        {
            switch (Type)
            {
                case PotionType.Damage:
                    return (int)Math.Floor(player.BaseDamage * 0.2);
                case PotionType.Luck:
                    return (int)Math.Floor(player.BaseLuck * 0.2);
                case PotionType.Speed:
                    return (int)Math.Floor(player.BaseSpeed * 0.2);
                case PotionType.Defense:
                    return (int)Math.Floor(player.BaseDefense * 0.2);
                default:
                    return 0;
            }
        }
    }
}
