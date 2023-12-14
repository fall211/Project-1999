using UnityEngine;

public class DestroyInvisible : MonoBehaviour
{
    private void OnBecameInvisible() {
        if (this.transform.parent != null) Destroy(this.transform.parent.gameObject);
        else Destroy(this.gameObject);
    }
}
