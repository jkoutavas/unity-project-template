using UnityEngine;

public class CapsuleMB : MonoBehaviour {
    private GameEngine game = new GameEngine();

    void Start() {
        game.SetSize(5);
        var size = game.Size;
        transform.localScale = new Vector3(size, size, size);
    }

    void Update() {

    }
}
