using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTD : MonoBehaviour
{
    private Vector2 direction;
    private float speed = 20f;
    private int damage = 4;

    private void Update()
    {
        if (direction == Vector2.zero || direction == null) return;
        transform.position += speed * Time.deltaTime * (Vector3)direction;
    }

    public void SetDirection(Vector2 direction){
        this.direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.TryGetComponent(out DamageableTD damageable)){
            damageable.ApplyDamage(-damage);
        }
        Destroy(this.gameObject);
    }
}
