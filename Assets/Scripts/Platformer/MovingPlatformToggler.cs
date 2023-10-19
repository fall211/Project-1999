using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformToggler : MonoBehaviour
{
    public MovingPlatform[] targetPlatforms;
    private float cooldown = 0f;

    private void Update(){
        if (cooldown <= 0) return;
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) OnButtonPress();
        }
    }


    private void OnButtonPress(){
        if (cooldown > 0) return;
        cooldown = 5f;
        Debug.Log("Button pressed!");
        ToggleMultiplePlatforms();
    }

    private void ToggleMultiplePlatforms(){
        foreach (MovingPlatform platform in targetPlatforms) {
            platform.MovePlatform();
        }
    }
}
