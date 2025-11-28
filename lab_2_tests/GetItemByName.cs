using Xunit;
using Lab2;

public class ItemRepositoryTests
{
    [Fact]
    public void GetItemByName_ShouldReturnItem_WhenItemExists()
    {
        string name = "Wooden Sword";
        var item = ItemRepository.GetItemByName(name);

        Assert.NotNull(item);
        Assert.Equal(name, item!.Name);
    }

    [Fact]
    public void GetItemByName_ShouldReturnNull_WhenItemDoesNotExist()
    {

        var item = ItemRepository.GetItemByName("NonExistingItem");

        Assert.Null(item);
    }
}
