namespace Lab2
{
    public abstract class Item
    {
        public string Name { get; set; }
        public float Weight { get; set; }

        public bool Is_quest { get; set; }

        public Item(string name, float weight, bool is_quest = false)
        {
            Name = name;
            Weight = weight;
            Is_quest = is_quest;
        }

        public abstract void Accept(IUseBehavior behavior, Player player);
    }
}