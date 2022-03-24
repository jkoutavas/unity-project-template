using UnityEngine;

namespace com.heynow.project {
    public class CapsuleMB : MonoBehaviour {
        private GameEngine game = new GameEngine();

        void Start() {
            setSize(1);
        }

        void Update() {
        }

        private void setSize(int newSize) {
            if (newSize >= 1 && newSize <= 10) {
                game.SetSize(newSize);
                var size = game.Size;
                transform.localScale = new Vector3(size, size, size);
            }
        }

        public void ChangeSize(int delta) {
            setSize(game.Size + delta);
        }
    }
}
