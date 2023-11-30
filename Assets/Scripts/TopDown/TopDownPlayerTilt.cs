using UnityEngine;

public class TopDownPlayerTilt : MonoBehaviour
{
    private TopDownPlayerController pController;
    private readonly float tiltMultiplier = 3f;
    void Start() {
        pController = GetComponentInParent<TopDownPlayerController>();
    }

    void Update() {
        transform.rotation = Quaternion.Euler(0f, 0f, -pController._velocity.x * tiltMultiplier);
    }
}
