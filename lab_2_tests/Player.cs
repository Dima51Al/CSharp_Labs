using Xunit;
using Lab2;

public class PlayerTests
{
    [Fact]
    public void Player_InitialStats_ShouldBeCorrect()
    {
        // Arrange
        var inventory = new Inventory(50f);
        var player = new Player(inventory);

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
        var inventory = new Inventory(50f);
        var player = new Player(inventory);
        var sword = (Weapon)ItemRepository.CreateItem("Wooden Sword");

        // Act
        player.EquipWeapon(sword);

        // Assert
        Assert.Equal(sword, player.EquippedWeapon);
        Assert.Equal(player.BaseDamage + sword.Damage, player.GetDamage());
    }

    [Fact]
    public void EquipArmor_ShouldUpdateGetDefenseAndLuckAndSpeed()
    {
        // Arrange
        var inventory = new Inventory(50f);
        var player = new Player(inventory);
        var helmet = (Armor)ItemRepository.CreateItem("Leather Helmet");
        var chest = (Armor)ItemRepository.CreateItem("Leather Chestplate");

        // Act
        player.EquipArmor(helmet);
        player.EquipArmor(chest);

        // Assert
        Assert.Equal(helmet, player.EquippedArmor[ArmorType.Head]);
        Assert.Equal(chest, player.EquippedArmor[ArmorType.Chest]);

        int expectedDefense = player.BaseDefense + helmet.Defense + chest.Defense;
        int expectedLuck = player.BaseLuck + helmet.Luck + chest.Luck;
        int expectedSpeed = player.BaseSpeed + helmet.Speed + chest.Speed;

        Assert.Equal(expectedDefense, player.GetDefense());
        Assert.Equal(expectedLuck, player.GetLuck());
        Assert.Equal(expectedSpeed, player.GetSpeed());
    }

    [Fact]
    public void AddBuff_ShouldIncreaseStats()
    {
        // Arrange
        var inventory = new Inventory(50f);
        var player = new Player(inventory);

        // Act
        player.AddBuff("Damage", 5);
        player.AddBuff("Defense", 3);

        // Assert
        Assert.Equal(player.BaseDamage + 5, player.GetDamage());
        Assert.Equal(player.BaseDefense + 3, player.GetDefense());
    }

    [Fact]
    public void ApplyPotion_ShouldApplyBonusAndRemoveFromInventory()
    {
        // Arrange
        var inventory = new Inventory(50f);
        var player = new Player(inventory);
        var potion = (Potion)ItemRepository.CreateItem("Damage Potion");
        player.Inventory.AddItem(potion);

        // Act
        player.ApplyPotion(potion);

        // Assert
        Assert.DoesNotContain(potion, player.Inventory.Items);
    }

    [Fact]
    public void ApplyPotion_NotInInventory_ShouldNotChangeStats()
    {
        // Arrange
        var inventory = new Inventory(50f);
        var player = new Player(inventory);
        var potion = (Potion)ItemRepository.CreateItem("Damage Potion");

        // Act
        player.ApplyPotion(potion);

        // Assert
        Assert.Equal(1, player.BaseDamage);
    }
}
