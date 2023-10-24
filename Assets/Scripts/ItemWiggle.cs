using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWiggle : MonoBehaviour
{
    private float timer = 0f;
    private void Update(){
        timer += Time.deltaTime;

        transform.localScale = Vector3.one * (1f + Mathf.Sin(timer * 5f) * 0.1f);
        transform.localEulerAngles = Vector3.forward * Mathf.Sin(timer * 5f) * 10f;
    }
}
