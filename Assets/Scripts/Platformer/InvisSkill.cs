using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisSkill : PowerUp
{

    private GameObject player;
    public float duration = 5f;
    public float cooldown = 30f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;
    private bool isActivated = false;
    private float timer = 0f;


    private void Start(){
        player = GameObject.Find("Player");
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
                DeactivateSkill();
            }
        }
    }

    public void ActivateSkill(){
        if (!onCooldown && !isActivated){
            onCooldown = true;
            isActivated = true;
            SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            Player playerScript = player.GetComponent<Player>();
            playerScript.detectable = false;
        }
    }
    private void DeactivateSkill(){
        SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        Player playerScript = player.GetComponent<Player>();
        playerScript.detectable = true;
    }

    public override void OnPickup(){
        GameStateManager.Instance.hasInvisSkill = true;
        // ActivateSkill();
        base.OnPickup();
        
    }
}
