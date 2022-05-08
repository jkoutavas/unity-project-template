using UnityEngine;

using com.heynow.games;

namespace com.heynow.project {
    public class ButtonManagerMB : MonoBehaviour {
        public void OnGrowButtonPress() => GameEngine.Get().Grow();

        public void OnShrinkButtonPress() => GameEngine.Get().Shrink();
    }
}
