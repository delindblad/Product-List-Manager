namespace UnitTests;

using ProdutListManager;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(ProductListManager.ValidateInput("aaa-333"));
        Assert.True(ProductListManager.ValidateInput("aaa-200"));
        Assert.True(ProductListManager.ValidateInput("bbb-500"));
        Assert.False(ProductListManager.ValidateInput("bbb500"));
        Assert.False(ProductListManager.ValidateInput("bbb-aaa"));
        Assert.False(ProductListManager.ValidateInput("444-aaa"));
        Assert.False(ProductListManager.ValidateInput("bbb--400"));
        Assert.False(ProductListManager.ValidateInput("aaa-100"));
        Assert.False(ProductListManager.ValidateInput("bbb-600"));
    }
}

