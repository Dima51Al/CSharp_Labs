namespace Lab2
{
    public class QuestItem : Item
    {
        public QuestItem(string name)
            : base(name, 0, true)
        {
        }


        public override void Accept(IUseBehavior behavior, Player player)
        {}
    }
}
