using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [HideInInspector] public bool isLocked = true;
    private SpriteRenderer spriteRenderer;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Unlock(){
        if (!isLocked) return;
        GetComponent<BoxCollider2D>().enabled = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.15f);
        isLocked = false;
    }
}
