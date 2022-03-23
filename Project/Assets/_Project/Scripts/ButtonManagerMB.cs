using UnityEngine;
public class ButtonManagerMB : MonoBehaviour {
    public CapsuleMB capsule;
    public void OnGrowButtonPress() {
        capsule.ChangeSize(1);
    }

    public void OnShrinkButtonPress() {
        capsule.ChangeSize(-1);
    }
}