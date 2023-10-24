using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool detectable = true;
    private int health = 100;
    private int maxHealth = 100;

    public int GetHealth() => health;
    public int GetMaxHealth() => maxHealth;
    public void ApplyToHealth(int amount){
        health += amount;
        if (health > maxHealth) health = maxHealth;
        if (health <= 0) Die();
    }

    public void ApplyToMaxHealth(int amount) => maxHealth += amount;




    private void Die(){
        Debug.Log("Player died");
    }


}
