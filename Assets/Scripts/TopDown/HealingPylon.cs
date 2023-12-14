using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPylon : MonoBehaviour
{
    private int health = 5;
    private float healRate = 2.5f;
    private float healTimer = 0f;

    SingularityAI boss;
    ParticleSystem particles;

    public void Start(){
        boss = GameObject.Find("Singularity").GetComponent<SingularityAI>();
        particles = transform.GetComponent<ParticleSystem>();
        particles.shape.rotation.Set(0f, 0f, Random.Range(0f, 360f));
    }

    void Update(){
        healTimer += Time.deltaTime;
        if (healTimer >= healRate){
            healTimer = 0f;
            boss.ApplyToHealth(1);
        }
    }
    public void ApplyToHealth(int amount){
        health -= 1;
        AudioManager.instance.AddToAudioQueue(5);
        transform.localScale = new Vector3(1f-1f/health, 1f-1f/health, 1f);
        if (health <= 1) Die();
    }

    private void Die(){
        // play sound
        Destroy(this.gameObject);
    }
}
