using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public List<ToggleableObstacle> horizontalObstacles;
    int horizontalObstacleIndex = 0;
    public List<ToggleableObstacle> verticalObstacles;
    int verticalObstacleIndex = 0;

    private bool isPickedUp = false;

    // Update is called once per frame
    void Update() {
        if (!isPickedUp) return;

        if (Input.GetMouseButtonDown(0)){
            // cycle horizontal obstacles
            horizontalObstacleIndex = (horizontalObstacleIndex + 1) % horizontalObstacles.Count;
            CycleHorizontalObstacles();
        }
        if (Input.GetMouseButtonDown(1)){
            // cycle vertical obstacles
            verticalObstacleIndex = (verticalObstacleIndex + 1) % verticalObstacles.Count;
            CycleVerticalObstacles();
        }
    }

    private void CycleHorizontalObstacles(){
        foreach (ToggleableObstacle obstacle in horizontalObstacles){
            obstacle.Toggle(false);
        }
        horizontalObstacles[horizontalObstacleIndex].Toggle(true);
    }

    private void CycleVerticalObstacles(){
        foreach (ToggleableObstacle obstacle in verticalObstacles){
            obstacle.Toggle(false);
        }
        verticalObstacles[verticalObstacleIndex].Toggle(true);
    }


    private void onPickUp(){
        isPickedUp = true;
        GetComponent<SpriteRenderer>().enabled = false;
        // TODO: enable UI to show what the player can do.
        GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>().ShowRemoteTip();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (isPickedUp) return;
        if (other.gameObject.CompareTag("Player")){
            onPickUp();
        }
    }
}
