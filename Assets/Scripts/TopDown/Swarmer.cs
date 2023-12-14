using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmer : MonoBehaviour
{
    private Transform _player;
    private PlayerTD playerTD;
    private Transform _boss;
    private Vector2 _offset;
    private Vector2 _lastPos;
    private Vector2 _moveDir;
    private bool _isLockedOn = false;
    private float lockOnDistance = 10f;
    private float _speed = 3.5f;
    private readonly float tiltMultiplier = 15f;
    int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        playerTD = _player.GetComponent<PlayerTD>();
        _boss = GameObject.Find("Singularity").transform;
        _offset = new Vector2(transform.position.x - _boss.position.x, transform.position.y - _boss.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is close enough, lock on to the player
        if (Vector2.Distance(transform.position, _player.position) < lockOnDistance){
            _isLockedOn = true;
        }
        if (Vector2.Distance(transform.position, _player.position) < 0.2f){
            playerTD.ApplyToHealth(-1);
            Die();
        }

        if (!_isLockedOn){
            _lastPos = transform.position;
            transform.position = new Vector2(_boss.position.x + _offset.x, _boss.position.y + _offset.y);
            _moveDir = ((Vector2)transform.position - _lastPos).normalized;
            transform.rotation = Quaternion.Euler(0f, 0f, -_moveDir.x * tiltMultiplier);
            return;
        }
        if (!playerTD.detectable) return;
        // move towards player
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

        // tilt towards player similar to how the player tilts
        Vector2 lookDir = _player.position - transform.position;
        lookDir = lookDir.normalized;
        transform.rotation = Quaternion.Euler(0f, 0f, -lookDir.x * tiltMultiplier);


    }

    public void ApplyToHealth(int amount){
        health += amount;
        AudioManager.instance.AddToAudioQueue(5);
        if (health <= 0) Die();
    }

    private void Die(){
        // play sound
        Destroy(this.gameObject);
    }
}
