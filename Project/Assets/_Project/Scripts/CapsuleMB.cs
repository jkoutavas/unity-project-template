using UnityEngine;
using com.csutil.model.immutable;

namespace com.heynow.project {
    public class CapsuleMB : MonoBehaviour {
        public GameEngineMB gmb;

        void Start() {
            gmb.Game.GetStore().AddStateChangeListener(state => state.size, (size) => {
                transform.localScale = new Vector3(size, size, size);
            });
        }

        void Update() {
        }
    }
}
