using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();

            // Создаём фабрику
            IMarketProductFactory factory = new MarketProductFactory();

            // Создаём продукты через фабрику
            MarketProduct apple = factory.Create(1, "Apple", 0.5f, 0.15f);
            MarketProduct banana = factory.Create(2, "Banana", 0.3f, 0.12f);

            // Создаём блюда через фабрику (cooktime != null)
            MarketProduct pasta = factory.Create(3, "Pasta", 5.0f, 0.5f, 15.0f);
            MarketProduct salad = factory.Create(4, "Salad", 4.0f, 0.3f, 5.0f);

            // Добавляем в маркет
            market.AddProduct(apple, 10);
            market.AddProduct(banana, 20);
            market.AddProduct(pasta, 5);
            market.AddProduct(salad, 8);

            market.PrintAllPositions();

            // Пользователь
            User user = new User("John Doe", 100.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");

            user.SetDiscount(10);
            user.TopBalance(5000.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");

            // Доставка и заказ
            Delivery delivery = new Delivery(5.0f, 4.0f); 
            Order order = new Order(user, delivery);

            // Позиции заказа
            order.AddPosition(new OrderPosition(apple, 2));
            order.AddPosition(new OrderPosition(pasta, 1));
            order.AddPosition(new OrderPosition(salad, 2));

            // Симуляция этапов доставки
            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();
        }
    }
}
