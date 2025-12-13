using Xunit;
using Lab3;

namespace Tests
{

    public class OrderTests
    {
        private User CreateUserWithBalanceAndDiscount(float balance, float discount)
        {
            var user = new User("John Doe", balance);
            user.SetDiscount(discount);
            return user;
        }

        private Delivery CreateDelivery(float distance)
        {
            return new Delivery(distance, 4.0f);
            
        }

        [Fact]
        public void Order_InitialState_ShouldBeUnpaidAndStatusZero()
        {
            // Arrange & Act
            var user = CreateUserWithBalanceAndDiscount(100.0f, 0.0f);
            var delivery = CreateDelivery(5.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());

            // Assert
            Assert.False(order.PaidStatus);
            Assert.Equal(0, order.DeliveryStatus);
            Assert.Equal(user, order.OrderUser);
            Assert.Equal(delivery, order.OrderDelivery);
        }

        [Fact]
        public void RemovePosition_ShouldRemoveFromList()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(100.0f, 0.0f);
            var delivery = CreateDelivery(5.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            var position = new OrderPosition(apple, 2);
            order.AddPosition(position);

            // Act
            order.RemovePosition(position);

            // Assert
            var positionsField = typeof(Order).GetField("positions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var positions = (System.Collections.Generic.List<OrderPosition>)positionsField.GetValue(order);
            Assert.Empty(positions);
        }

        [Fact]
        public void GetOrderCookTime_ShouldSumDishCookTimesOnly()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(100.0f, 0.0f);
            var delivery = CreateDelivery(5.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);
            var salad = new MarketDish(4, "Salad", 4.0f, 0.3f, 5.0f);
            order.AddPosition(new OrderPosition(apple, 2)); // 0
            order.AddPosition(new OrderPosition(pasta, 1)); // 15
            order.AddPosition(new OrderPosition(salad, 2)); // 10

            // Act
            float cookTime = order.GetOrderCookTime();

            // Assert
            Assert.Equal(25.0f, cookTime);
        }


        [Fact]
        public void GetOrderDeliveryTime_ShouldSumCookAndDeliveryTime()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(100.0f, 0.0f);
            var delivery = CreateDelivery(3.0f); // 600 time
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);
            order.AddPosition(new OrderPosition(pasta, 2)); // 30

            // Act
            float deliveryTime = order.GetOrderDeliveryTime();

            // Assert
            Assert.Equal(630.0f, deliveryTime); // 30 + 600
        }

        [Fact]
        public void PayOrder_EnoughBalance_ShouldReduceBalanceSetPaidTrueAndReturnTrue()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(1000.0f, 0.0f);
            var delivery = CreateDelivery(1.0f); // 100 cost
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 10.0f, 0.15f);
            order.AddPosition(new OrderPosition(apple, 2)); // 20 cost

            // Act
            bool result = order.PayOrder();

            // Assert
            Assert.True(result);
            Assert.True(order.PaidStatus);
        }

        [Fact]
        public void PayOrder_InsufficientBalance_ShouldNotReduceAndReturnFalse()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(50.0f, 0.0f);
            var delivery = CreateDelivery(1.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 10.0f, 0.15f);
            order.AddPosition(new OrderPosition(apple, 2));

            // Act
            bool result = order.PayOrder();

            // Assert
            Assert.False(result);
            Assert.False(order.PaidStatus);
            Assert.Equal(50.0f, user.Balance);
        }

        [Fact]
        public void DeliveryNextStep_UnpaidWithEnoughBalance_ShouldPayAndSetStatusTo1()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(1000.0f, 0.0f);
            var delivery = CreateDelivery(1.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 10.0f, 0.15f);
            order.AddPosition(new OrderPosition(apple, 2));

            // Act
            bool result = order.DeliveryNextStep();

            // Assert
            Assert.True(result);
            Assert.True(order.PaidStatus);
            Assert.Equal(1, order.DeliveryStatus);
        }

        [Fact]
        public void DeliveryNextStep_Status1_ShouldSetTo2AndPrintCookTime()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(1000.0f, 0.0f);
            var delivery = CreateDelivery(1.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);
            order.AddPosition(new OrderPosition(pasta, 1));
            order.PayOrder();
            order.SetDeliveryStatus(1);

            // Act
            bool result = order.DeliveryNextStep();

            // Assert
            Assert.True(result);
            Assert.Equal(2, order.DeliveryStatus);

        }

        [Fact]
        public void DeliveryNextStep_Status2_ShouldSetTo3AndPrintDeliveryTime()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(1000.0f, 0.0f);
            var delivery = CreateDelivery(2.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);
            order.AddPosition(new OrderPosition(pasta, 1));
            order.PayOrder();
            order.SetDeliveryStatus(2);

            // Act
            bool result = order.DeliveryNextStep();

            // Assert
            Assert.True(result);
            Assert.Equal(3, order.DeliveryStatus);
        }

        [Fact]
        public void DeliveryNextStep_Status3_ShouldPrintDeliveredAndStayAt3()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(1000.0f, 0.0f);
            var delivery = CreateDelivery(1.0f);
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            order.PayOrder();
            order.SetDeliveryStatus(3);

            // Act
            bool result = order.DeliveryNextStep();

            // Assert
            Assert.True(result);
            Assert.Equal(4, order.DeliveryStatus);
        }

        [Fact]
        public void DeliveryNextStep_UnpaidInsufficientBalance_ShouldReturnFalse()
        {
            // Arrange
            var user = CreateUserWithBalanceAndDiscount(50.0f, 0.0f);
            var delivery = CreateDelivery(1.0f); // 100
            var order = new Order(user, delivery);
            order.SetPricingStrategy(new StandardPricing());
            var apple = new MarketProduct(1, "Apple", 10.0f, 0.15f);
            order.AddPosition(new OrderPosition(apple, 2));

            // Act
            bool result = order.DeliveryNextStep();

            // Assert
            Assert.False(result);
            Assert.False(order.PaidStatus);
            Assert.Equal(0, order.DeliveryStatus);
            Assert.Equal(50.0f, user.Balance);
        }
    }


}
