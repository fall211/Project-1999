using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWiggle : MonoBehaviour
{
    private float timer = 0f;
    private Vector3 originalScale;
    private void Start(){
        originalScale = transform.localScale;
    }
    private void Update(){
        timer += Time.deltaTime;

        transform.localScale = originalScale * (1f + Mathf.Sin(timer * 5f) * 0.1f);
        transform.localEulerAngles = Vector3.forward * Mathf.Sin(timer * 5f) * 10f;
    }
}
