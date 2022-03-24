using Xunit;
using com.csutil.model.immutable;
using com.heynow.games;
namespace test;

public class UnitTestCore {
    [Fact]
    public void TestState() {
        var data = new GameEngine.State();
        var size = 0;
        var store = new DataStore<GameEngine.State>(GameEngine.Reducers.ReduceState, data);
        store.AddStateChangeListener(state => state.size, (s) => {
            size = s;
        });
        Assert.Equal(1, size);

        store.Dispatch(new GameEngine.Actions.ChangeSize() { newSize = 5 });
        Assert.Equal(5, size);
    }

    [Fact]
    public void TestGameInstance() {
        var ge = new GameEngine();

        var size = 0;
        ge.GetStore().AddStateChangeListener(state => state.size, (s) => {
            size = s;
        });

        ge.GetStore().Dispatch(new GameEngine.Actions.ChangeSize() { newSize = 23 });
        Assert.Equal(23, size);
    }

    [Fact]
    public void TestShrinkAndGrow() {
        var ge = new GameEngine();

        var size = 0;
        ge.GetStore().AddStateChangeListener(state => state.size, (s) => {
            size = s;
        });

        ge.Grow();
        Assert.Equal(2, size);
        ge.Shrink();
        Assert.Equal(1, size);
    }

    [Fact]
    public void TestShrinkTooMuch() {
        var ge = new GameEngine();

        var size = 0;
        ge.GetStore().AddStateChangeListener(state => state.size, (s) => {
            size = s;
        });

        ge.Shrink();
        Assert.Equal(1, size);
    }
}