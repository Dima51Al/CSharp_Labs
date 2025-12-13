using Xunit;
using Lab3;

namespace Tests
{

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
}
