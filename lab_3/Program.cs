using System;
using System.Collections.Generic; // Для List, если нужно

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            Market market = new Market();


            MarketProduct apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            MarketProduct banana = new MarketProduct(2, "Banana", 0.3f, 0.12f);
            MarketDish pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);
            MarketDish salad = new MarketDish(4, "Salad", 4.0f, 0.3f, 5.0f);


            market.AddProduct(apple, 10);
            market.AddProduct(banana, 20);
            market.AddProduct(pasta, 5);
            market.AddProduct(salad, 8);

            market.PrintAllPositions();


            User user = new User("John Doe", 100.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");

            user.SetDiscount(10);
  

            user.TopBalance(5000.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");


            Delivery delivery = new Delivery(5.0f, 4.0f); 
            Order order = new Order(user, delivery);


            OrderPosition applePos = new OrderPosition(apple, 2);
            OrderPosition pastaPos = new OrderPosition(pasta, 1);
            OrderPosition saladPos = new OrderPosition(salad, 2);

            order.AddPosition(applePos);
            order.AddPosition(pastaPos);
            order.AddPosition(saladPos);


            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();

        }

    }
}