using UnityEngine;
using com.heynow.games;

namespace com.heynow.project {
    public class GameEngineMB : MonoBehaviour {
        public GameEngine Game;

        // Start is called before the first frame update
        void Start() {
            Game = new GameEngine();
        }

        // Update is called once per frame
        void Update() {
        }
    }
}
