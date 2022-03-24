using UnityEngine;

namespace com.heynow.project {
    public class ButtonManagerMB : MonoBehaviour {
        public GameEngineMB gmb;
        public void OnGrowButtonPress() => gmb.Game.Grow();

        public void OnShrinkButtonPress() => gmb.Game.Shrink();
    }
}
