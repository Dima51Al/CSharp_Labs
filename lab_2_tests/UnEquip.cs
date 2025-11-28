using Xunit;
using Lab2;

public class UnEquipTest
{
    [Fact]
    public void Player_InitialStats_ShouldBeCorrect()
    {
        // Arrange
        var player = new Player(50);

        // Act & Assert
        Assert.Equal(1, player.BaseDamage);
        Assert.Equal(1, player.BaseLuck);
        Assert.Equal(20, player.BaseSpeed);
        Assert.Equal(4, player.BaseDefense);
        Assert.Null(player.EquippedWeapon);
        foreach (var armor in player.EquippedArmor.Values)
            Assert.Null(armor);
        Assert.Empty(player.Inventory.Items);
    }

    [Fact]
    public void EquipWeapon_ShouldUpdateGetDamage()
    {
        // Arrange
        var player = new Player(50);
        var sword = (Weapon)ItemRepository.CreateItem("Wooden Sword");

        // Act
        player.EquipWeapon(sword);
        player.UnEquipWeapon(sword);

        // Assert
        Assert.Null(player.EquippedWeapon);
    }

}
