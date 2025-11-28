using Xunit;
using Lab2;

public class WeaponLevelUpTests
{
    [Fact]
    public void LevelUp_ShouldIncreaseLevel_AndRemoveDuplicate()
    {
        // Arrange
        var player = new Player(50);
        var w1 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
        var w2 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
        player.Inventory.AddItem(w1);
        player.Inventory.AddItem(w2);
        int oldDamage = w1.Damage;

        // Act
        w1.LevelUp(player, w2);

        // Assert
        Assert.Equal(2, w1.Level);
        Assert.Single(player.Inventory.Items);
    }



    [Fact]
    public void Weapon_ShouldLevelUp_ToLevel3()
    {
        // Arrange
        var player = new Player(50);

        var w1 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
        var w2 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
        var w3 = (Weapon)ItemRepository.CreateItem("Wooden Sword");
        var w4 = (Weapon)ItemRepository.CreateItem("Wooden Sword");

        player.Inventory.AddItem(w1);
        player.Inventory.AddItem(w2);
        player.Inventory.AddItem(w3);
        player.Inventory.AddItem(w4);


        // Act
        w1.LevelUp(player, w2);
        w3.LevelUp(player, w4);

        Assert.Equal(2, w3.Level);
        w1.LevelUp(player, w3);

        // Assert
        Assert.Equal(3, w1.Level);
        Assert.Single(player.Inventory.Items);
    }


}