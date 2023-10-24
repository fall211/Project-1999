using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform finish;
    private Transform player;
    [SerializeField] float distanceToInteract = 1.5f;
    private int keys = 0;
    private List<LockedDoor> doors = new();
    [SerializeField] private GameObject interactTip;
    [SerializeField] private GameObject remoteTip;

    private void Awake(){
        if (start != null){
            player = GameObject.Find("Player").transform;
            player.position = start.position;
        }
    }
    private void Start(){
        doors.AddRange(FindObjectsOfType<LockedDoor>());
    }

    public void AddKey() => keys++;
    public void UseKey() => keys--;
    public int GetKeyCount() => keys;


    private float GetDistanceToNearestDoor(Vector3 position){
        float minDistance = float.MaxValue;
        foreach (LockedDoor door in doors){
            float distance = Vector3.Distance(position, door.transform.position);
            if (distance < minDistance){
                minDistance = distance;
            }
        }
        return minDistance;
    }

    private void OpenNearestDoor(Vector3 position){
        float minDistance = float.MaxValue;
        LockedDoor nearestDoor = null;
        foreach (LockedDoor door in doors){
            float distance = Vector3.Distance(position, door.transform.position);
            if (distance < minDistance){
                minDistance = distance;
                nearestDoor = door;
            }
        }
        if (nearestDoor != null){
            nearestDoor.Unlock();
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            float distance = GetDistanceToNearestDoor(player.position);
            if (distance < distanceToInteract){
                if (keys > 0){
                    OpenNearestDoor(player.position);
                    UseKey();
                }
            }
        }

        if (Vector3.Distance(player.position, finish.position) < distanceToInteract / 3f){
            if (Input.GetKeyDown(KeyCode.E)){
                GameStateManager.Instance.UnlockGame("Maze");
                MySceneManager.Instance.LoadScene("MainMenu");
            }
        }

    }

    public void ShowRemoteTip(){
        remoteTip.SetActive(true);
    }

    public void ShowInteractTip(){
        interactTip.SetActive(true);
    }




}
