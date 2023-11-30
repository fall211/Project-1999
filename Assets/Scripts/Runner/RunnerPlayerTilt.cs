using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class RunnerPlayerTilt : MonoBehaviour
{
    private RunnerManager _runnerManager;
    private float _tilt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _runnerManager = GameObject.Find("RunnerManager").GetComponent<RunnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _tilt = -_runnerManager.speed * 3f;
        _tilt = Mathf.Clamp(_tilt, -30f, 30f);
        transform.rotation = Quaternion.Euler(0f, 0f, _tilt);
    }
}
