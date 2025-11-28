using System;

namespace Lab3
{
    public class User
    {
        public string Name { get; set; }
        public float Balance { get; private set; }

        public float Discount { get; private set; }

        public User(string name, float balance)
        {
            Name = name;
            Balance = balance;
        }

        public void TopBalance(float value)
        {
            Balance += value;
        }
        public bool ReduceBalance(float value)
        {
            if (Balance >= value)
            {
                Balance -= value;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool SetDiscount(float discount)
        {
            if (0 < discount && discount < 100)
            {
                Discount = discount;
                return true;
            }
            else
            {
                return false;
            }

        }

        public float GetDiscount()
        {
            return (1 - Discount / 100);
        }

        
    }
}