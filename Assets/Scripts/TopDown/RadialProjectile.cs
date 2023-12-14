using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialProjectile : MonoBehaviour
{
    public float lifeTime = 10f;

    void Start(){
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out DamageableTD damageable)){
            if (damageable.damageableType == DamageableTD.DamageableType.Player){
                damageable.ApplyDamage(-1);
                Destroy(this.gameObject);
            }
        }
    }
}
