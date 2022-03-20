using Xunit;

namespace test;

public class UnitTestCore
{
    [Fact]
    public void TestSize()
    {
        var core = new GameEngine();
        Assert.Equal(0, core.Size);

        core.SetSize(5);
        Assert.Equal(5, core.Size);
    }
}