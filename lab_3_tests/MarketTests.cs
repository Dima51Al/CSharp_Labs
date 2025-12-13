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

    
}