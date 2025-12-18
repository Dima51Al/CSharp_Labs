using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();

            IMarketProductFactory factory = new MarketProductFactory();

            MarketProduct apple = factory.Create(1, "apple", 0.5f, 0.15f);
            MarketProduct banana = factory.Create(2, "banana", 0.3f, 0.12f);
            MarketProduct pasta = factory.Create(3, "pasta", 5.0f, 0.5f, 15.0f);
            MarketProduct salad = factory.Create(4, "salad", 4.0f, 0.3f, 5.0f);

            market.AddProduct(apple, 10);
            market.AddProduct(banana, 20);
            market.AddProduct(pasta, 5);
            market.AddProduct(salad, 8);

            market.PrintAllPositions();

            User user = new User("Дмитрий", 100.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");

            user.SetDiscount(10);
            user.TopBalance(5000.0f);
            Console.WriteLine($"текущий баланс: {user.Balance}");

            IDelivery delivery = new Delivery(5.0f, 4.0f);
            delivery = new ExpressDeliveryDecorator(delivery);

            Order order = new Order(user, delivery);
            order.Subscribe(new LoggerObserver());

            order.AddPosition(new OrderPosition(apple, 2));
            order.AddPosition(new OrderPosition(pasta, 1));
            order.AddPosition(new OrderPosition(salad, 2));

            order.SetPricingStrategy(new StandardPricing());

            Console.WriteLine($"Итоговая стоимость заказа: {order.GetOrderCost():0.00}");

            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();
            order.DeliveryNextStep();

            order.SetPricingStrategy(new PromoPricing(0.85f));
            Console.WriteLine($"Стоимость с промо-скидкой: {order.GetOrderCost():0.00}");
        }
    }
}
