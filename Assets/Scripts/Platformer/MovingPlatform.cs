using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public AnimationCurve speedCurve;
    public float travelTime = 5f;

    private int currentWaypoint = 0;
    private int targetWaypoint = 0;
    private float timer = 0f;

    private void Start(){
        if (waypoints.Length > 0) {
            transform.position = waypoints[0].position;
        }
    }

    private void LateUpdate(){
        if (Input.GetKeyDown(KeyCode.R)) MovePlatform();

        if (waypoints.Length == 0) return;
        if (currentWaypoint == targetWaypoint) return;
        timer += Time.deltaTime;

        if (timer >= travelTime) {
            transform.position = waypoints[targetWaypoint].position;
            currentWaypoint = targetWaypoint;
        }

        transform.position = Vector3.Lerp(
            waypoints[currentWaypoint].position,
            waypoints[targetWaypoint].position,
            speedCurve.Evaluate(timer / travelTime)
        );

        
    }

    public void MovePlatform(){
        timer = 0f;
        targetWaypoint = (targetWaypoint + 1) % waypoints.Length;
    }

}
