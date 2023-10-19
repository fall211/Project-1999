using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isPickedUp = false;
    private PuzzleManager puzzleManager;

    private void Start(){
        puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

    private void onPickUp(){
        isPickedUp = true;
        GetComponent<SpriteRenderer>().enabled = false;
        puzzleManager.AddKey();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Player")){
            onPickUp();
        }
    }
}
