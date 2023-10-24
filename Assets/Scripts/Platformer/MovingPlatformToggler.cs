using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformToggler : MonoBehaviour
{
    private bool pressedOnce = false;
    private bool animating = false;
    public MovingPlatform[] targetPlatforms;

    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                pressedOnce = true;
                OnButtonPress();
            }
            animating = true;
        }
    }

    private void Update(){
        if (pressedOnce) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10f);
            return;
        }

        if (animating){
            transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time * 6f) * 0.1f);
        } else {
            transform.localScale = Vector3.one;
        }
    }

    private void OnButtonPress(){
        ToggleMultiplePlatforms();
        animating = false;
        transform.localScale = Vector3.one * 0.7f;
    }

    private void ToggleMultiplePlatforms(){
        foreach (MovingPlatform platform in targetPlatforms) {
            platform.MovePlatform();
        }

    }
}
