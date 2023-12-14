using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableTD : MonoBehaviour
{
    public DamageableType damageableType;
    public void ApplyDamage(int amount){
        if (damageableType == DamageableType.Player){
            PlayerTD player = GetComponent<PlayerTD>();
            if (player != null) player.ApplyToHealth(amount);
        }

        if (damageableType == DamageableType.Boss){
            SingularityAI boss = GetComponentInParent<SingularityAI>();
            if (boss != null) boss.ApplyToHealth(amount);
        }
        if (damageableType == DamageableType.Enemy){
            Swarmer enemy = GetComponent<Swarmer>();
            if (enemy != null) enemy.ApplyToHealth(amount);
        }
        if (damageableType == DamageableType.Obstacle){
            HealingPylon obstacle = GetComponent<HealingPylon>();
            if (obstacle != null) obstacle.ApplyToHealth(amount);
        }
    }

    public enum DamageableType{
        Player,
        Enemy,
        Boss,
        Obstacle
    }
}
