#nullable enable

using com.csutil.model.immutable;

/**
 * A contrived example of a game engine. It's capable of actions against its "size" state.
 **/
namespace com.heynow.games {
    public class GameEngine {
        static GameEngine? ge = null;

        public class State {
            public readonly int size;

            public State(int size = 1) {
                this.size = size;
            }
        }

        private State state;
        public DataStore<State> store;

        public static GameEngine Get() {
            if (ge == null) {
                ge = new GameEngine();
            }
            return ge;
        }

        public GameEngine() {
            ge = this;
            state = new State();
            store = new DataStore<State>(Reducers.ReduceState, state);
        }

        // Provides a chokepoint for access to the engine's Store.
        public DataStore<State> GetStore() => store;

        public void DoAmazingThings() {
            // If we had a real game engine, we'd have all kinds of methods to compute
            // game state and in turn dispatch actions on the store for listening parties
            // to act on.
        }

        // These Grow() and Shrink() methods are examples of dispatching an action from 
        // within the engine itself. You may want to privatize your actions and have all 
        // actions wrapped-up in engine methods.
        public void Grow() => store.Dispatch(new Actions.Grow());

        public void Shrink() => store.Dispatch(new Actions.Shrink());

        public class Actions {
            public class ChangeSize : Actions { public int newSize; }
            public class Grow : Actions { }
            public class Shrink : Actions { }
        }

        public static class Reducers {
            // The most outer reducer is public to be passed into the store:
            public static State ReduceState(State previousState, object action) {
                if (action is Actions.ChangeSize) {
                    bool changed = false;
                    var newSize = previousState.size.Mutate(action, ReduceSize, ref changed);
                    if (changed) { return new State(newSize); }
                } else if (action is Actions.Grow && previousState.size < 5) {
                    return new State(previousState.size + 1);
                } else if (action is Actions.Shrink && previousState.size > 1) {
                    return new State(previousState.size - 1);
                }
                return previousState;
            }

            private static int ReduceSize(int oldSize, object action) {
                if (action is Actions.ChangeSize s) { return s.newSize; }
                return oldSize;
            }
        }
    }
}
