using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftItem : MonoBehaviour
{
    private RunnerManager _runnerManager;
    // Start is called before the first frame update
    void Start()
    {
        _runnerManager = GameObject.Find("RunnerManager").GetComponent<RunnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _runnerManager.speed * Time.deltaTime;

        if (transform.position.x < -10f) Destroy(gameObject);
    }
}
