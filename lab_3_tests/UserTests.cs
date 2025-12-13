using Xunit;
using Lab3;

namespace Tests
{

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

}
