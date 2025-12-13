using Xunit;
using Lab3;

namespace Tests
{
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

}
