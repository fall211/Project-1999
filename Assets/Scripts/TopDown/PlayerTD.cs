using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTD : MonoBehaviour
{
    [HideInInspector] public bool detectable = true;
    private int health = 5;
    private int maxHealth = 5;
    public List<Image> hearts = new();
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    public int GetHealth() => health;
    public void ApplyToHealth(int amount){
        if (amount < 0 && !detectable) return;
        if (amount < 0) AudioManager.instance.AddToAudioQueue(6);
        
        health += amount;
        if (health > maxHealth) health = maxHealth;
        if (health <= 0) Die();

        for (int i = 0; i < hearts.Count; i++){
            if (i < health) hearts[i].sprite = fullHeart;
            else hearts[i].sprite = emptyHeart;
        }
    }


    private void Die(){
        SpriteRenderer spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        detectable = false;
        TopDownManager.Instance.EndGame(false);
    }

}
