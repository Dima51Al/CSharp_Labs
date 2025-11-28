using Xunit;
using Lab2;
using System;

public class ItemRepositoryCreateTests
{
    [Fact]
    public void CreateItem_ShouldReturnNewInstanceOfWeapon()
    {
        // Arrange
        string name = "Wooden Sword";

        // Act
        var item = ItemRepository.CreateItem(name);

        // Assert
        Assert.NotNull(item);
        Assert.IsType<Weapon>(item);
        Assert.Equal(name, item.Name);
    }

    [Fact]
    public void CreateItem_ShouldThrow_WhenItemDoesNotExist()
    {
        Assert.Throws<InvalidOperationException>(() => ItemRepository.CreateItem("Unknown Item"));
    }

    [Fact]
    public void CreateItem_ShouldReturnDistinctInstances()
    {
        // Arrange
        string name = "Wooden Sword";

        // Act
        var item1 = ItemRepository.CreateItem(name);
        var item2 = ItemRepository.CreateItem(name);

        // Assert
        Assert.NotSame(item1, item2);
    }
}
