using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTilt : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly float tiltMultiplier = 3f;
    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update() {
        transform.rotation = Quaternion.Euler(0f, 0f, -rb.velocity.x * tiltMultiplier);
    }
}
