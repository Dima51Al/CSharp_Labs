namespace Lab2
{
    public abstract class Item
    {
        public string Name { get; set; }
        public float Weight { get; set; }

        public bool IsQuest { get; set; }

        public Item(string name, float weight, bool isQuest = false)
        {
            Name = name;
            Weight = weight;
            IsQuest = isQuest;
        }

        public abstract void Accept(IUseBehavior behavior, Player player);
    }
}