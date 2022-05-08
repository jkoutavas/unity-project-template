using UnityEngine;
using com.csutil.model.immutable;

using com.heynow.games;

namespace com.heynow.project {
    public class CapsuleMB : MonoBehaviour {

        void Start() {
            GameEngine.Get().GetStore().AddStateChangeListener(state => state.size, (size) => {
                transform.localScale = new Vector3(size, size, size);
            });
        }

        void Update() {
        }
    }
}
