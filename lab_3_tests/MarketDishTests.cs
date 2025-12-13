using Xunit;
using Lab3;

namespace Tests
{
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
