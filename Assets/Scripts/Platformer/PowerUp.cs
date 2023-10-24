using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    


    public virtual void OnPickup(){
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            OnPickup();
        }
    }


}
