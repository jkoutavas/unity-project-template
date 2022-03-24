using com.csutil.model.immutable;

namespace com.heynow.games {
    public class GameEngine {
        public class State {
            public readonly int size;

            public State(int size = 1) {
                this.size = size;
            }
        }

        private State state;
        public DataStore<State> store;

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

        public GameEngine() {
            state = new State();
            store = new DataStore<State>(Reducers.ReduceState, state);
        }

        public DataStore<State> GetStore() => store;

        public void Grow() {
            var size = state.size;
            store.Dispatch(new Actions.Grow());
        }

        public void Shrink() {
            var size = state.size;
            store.Dispatch(new Actions.Shrink());
        }
    }
}
