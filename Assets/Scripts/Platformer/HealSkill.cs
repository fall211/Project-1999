using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSkill : PowerUp
{
    private Player playerScript;

    public float duration = 10f;
    public float cooldown = 60f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;
    private bool isActivated = false;
    private float timer = 0f;
    private int healAmount = 5;
    private int healInterval = 1;
    private float healTimer = 0f;


    private void Start(){
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update(){
        if (onCooldown){
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldown){
                onCooldown = false;
                cooldownTimer = 0f;
            }
        }
        if (isActivated){
            timer += Time.deltaTime;
            if (timer >= duration){
                isActivated = false;
                timer = 0f;
            }
            healTimer += Time.deltaTime;
            if (healTimer >= healInterval){
                healTimer = 0f;
                playerScript.ApplyToHealth(healAmount);
            }
        }
    }

    public void ActivateSkill(){
        if (!onCooldown && !isActivated){
            onCooldown = true;
            isActivated = true;
        }
    }

    public override void OnPickup(){
        GameStateManager.Instance.hasHealthSkill = true;
        // ActivateSkill();
        base.OnPickup();
        
    }
}
