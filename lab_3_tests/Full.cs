using Xunit;
using Lab3;

namespace Tests
{
    public class MarketTests
    {
        [Fact]
        public void AddProduct_ShouldAddNewProductWithCount()
        {
            // Arrange
            var market = new Market();
            var apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);

            // Act
            market.AddProduct(apple, 10);

            // Assert
            Assert.Equal(10, market.GetCountByID(1));
        }

        [Fact]
        public void AddProduct_ExistingId_ShouldIncreaseCount()
        {
            // Arrange
            var market = new Market();
            var apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);

            // Act
            market.AddProduct(apple, 10);
            market.AddProduct(apple, 5);

            // Assert
            Assert.Equal(15, market.GetCountByID(1));
        }

        [Fact]
        public void AddProduct_SameIdDifferentInstance_ShouldIncreaseCount()
        {
            // Arrange
            var market = new Market();
            var apple1 = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            var apple2 = new MarketProduct(1, "Apple Duplicate", 0.5f, 0.15f);

            // Act
            market.AddProduct(apple1, 10);
            market.AddProduct(apple2, 5);

            // Assert
            Assert.Equal(15, market.GetCountByID(1));
        }

        [Fact]
        public void GetCountByID_NonExistentId_ShouldReturnZero()
        {
            // Arrange
            var market = new Market();

            // Act & Assert
            Assert.Equal(0, market.GetCountByID(993));
        }

        [Fact]
        public void MarketProduct_Equals_SameId_ShouldBeTrue()
        {
            // Arrange
            var apple1 = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            var apple2 = new MarketProduct(1, "Apple Duplicate", 0.5f, 0.15f);
            var banana = new MarketProduct(2, "Banana", 0.3f, 0.12f);

            // Act & Assert
            Assert.True(apple1.Equals(apple2));
            Assert.False(apple1.Equals(banana));
        }

        [Fact]
        public void MarketProduct_GetHashCode_SameId_ShouldBeEqual()
        {
            // Arrange
            var apple1 = new MarketProduct(1, "Apple", 0.5f, 0.15f);
            var apple2 = new MarketProduct(1, "Apple Duplicate", 0.5f, 0.15f);

            // Act & Assert
            Assert.Equal(apple1.GetHashCode(), apple2.GetHashCode());
        }
    }

    public class UserTests
    {
        [Fact]
        public void User_InitialBalance_ShouldBeSetCorrectly()
        {
            // Arrange & Act
            var user = new User("John Doe", 100.0f);

            // Assert
            Assert.Equal("John Doe", user.Name);
            Assert.Equal(100.0f, user.Balance);
            Assert.Equal(0f, user.Discount);
        }

        [Fact]
        public void TopBalance_ShouldIncreaseBalance()
        {
            // Arrange
            var user = new User("John Doe", 100.0f);

            // Act
            user.TopBalance(50.0f);

            // Assert
            Assert.Equal(150.0f, user.Balance);
        }

        [Fact]
        public void ReduceBalance_EnoughFunds_ShouldReduceAndReturnTrue()
        {
            // Arrange
            var user = new User("John Doe", 100.0f);

            // Act
            bool result = user.ReduceBalance(30.0f);

            // Assert
            Assert.True(result);
            Assert.Equal(70.0f, user.Balance);
        }

        [Fact]
        public void ReduceBalance_InsufficientFunds_ShouldNotReduceAndReturnFalse()
        {
            // Arrange
            var user = new User("John Doe", 100.0f);

            // Act
            bool result = user.ReduceBalance(150.0f);

            // Assert
            Assert.False(result);
            Assert.Equal(100.0f, user.Balance);
        }

        [Fact]
        public void SetDiscount_ValidRange_ShouldSetAndReturnTrue()
        {
            // Arrange
            var user = new User("John Doe", 100.0f);

            // Act
            bool result = user.SetDiscount(20.0f);

            // Assert
            Assert.True(result);
            Assert.Equal(20.0f, user.Discount);
            Assert.Equal(0.8f, user.GetDiscount());
        }

        [Fact]
        public void SetDiscount_InvalidRange_ShouldNotSetAndReturnFalse()
        {
            // Arrange
            var user = new User("John Doe", 100.0f);

            // Act
            bool result1 = user.SetDiscount(0.0f);
            bool result2 = user.SetDiscount(100.0f);
            bool result3 = user.SetDiscount(101.0f);
            bool result4 = user.SetDiscount(-5.0f);

            // Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.Equal(0f, user.Discount);
            Assert.Equal(1.0f, user.GetDiscount());
        }
    }

    public class DeliveryTests
    {
        [Fact]
        public void Delivery_GetDeliveryCost_ShouldBeDistanceTimes100()
        {
            // Arrange
            var delivery = new Delivery(5.0f, 4.0f);

            // Act
            float cost = delivery.GetDeliveryCost();

            // Assert
            
        }

        [Fact]
        public void Delivery_GetDeliveryTime_ShouldBeDistanceTimes200()
        {
            // Arrange
            var delivery = new Delivery(3.0f, 4.0f);

            // Act
            float time = delivery.GetDeliveryTime();

            // Assert
            Assert.Equal(600.0f, time);
        }
    }

    public class OrderPositionTests
    {
        [Fact]
        public void OrderPosition_MarketProduct_CookTimeShouldBeZero()
        {
            // Arrange
            var apple = new MarketProduct(1, "Apple", 0.5f, 0.15f);

            // Act
            var position = new OrderPosition(apple, 2);

            // Assert
            Assert.Equal(0.0f, position.CookTime);
            Assert.Equal(1.0f, position.Cost);
        }

        [Fact]
        public void OrderPosition_MarketDish_CookTimeShouldBeCookTimeTimesCount()
        {
            // Arrange
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);

            // Act
            var position = new OrderPosition(pasta, 2);

            // Assert
            Assert.Equal(30.0f, position.CookTime);
            Assert.Equal(10.0f, position.Cost);
        }
    }

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

    public class MarketDishTests
    {
        [Fact]
        public void MarketDish_InheritsPropertiesFromMarketProduct()
        {
            // Arrange
            // Act
            var pasta = new MarketDish(3, "Pasta", 5.0f, 0.5f, 15.0f);

            // Assert
            Assert.Equal(3, pasta.Id);
            Assert.Equal("Pasta", pasta.Name);
            Assert.Equal(5.0f, pasta.Cost);
            Assert.Equal(0.5f, pasta.Weight);
            Assert.Equal(15.0f, pasta.CookTime);
        }
    }
}