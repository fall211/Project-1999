using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleableObstacle : MonoBehaviour
{
    public bool isOn;

    private void Start(){
        Toggle(isOn);
    }

    public void Toggle(bool isOn)
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.enabled = isOn;
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        
        foreach (SpriteRenderer sprite in sprites) {
            sprite.color = isOn ? Color.white : new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.15f);
        }
    }
}
