using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingFloor : MonoBehaviour
{
    public float minXcoord = -40f;
    private float transformAmount;
    private RunnerManager runnerManager;
    // Start is called before the first frame update
    void Start()
    {
        transformAmount = -minXcoord * 2;
        runnerManager = GameObject.Find("RunnerManager").GetComponent<RunnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= runnerManager.speed * Time.deltaTime * Vector3.right;
        if (transform.localPosition.x < minXcoord)
            transform.localPosition = -minXcoord * Vector3.right;
    }
}
