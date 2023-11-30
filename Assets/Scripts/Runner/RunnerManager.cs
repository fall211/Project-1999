using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    public float speed = 1f;


    void Update()
    {
        speed += Time.deltaTime * 0.1f;
        speed = Mathf.Clamp(speed, 1f, 10f);
    }
}
