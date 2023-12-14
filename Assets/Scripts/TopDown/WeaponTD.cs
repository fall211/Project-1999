using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTD : MonoBehaviour
{

    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    
    private Vector2 _mousePos;
    private SpriteRenderer _spriteRenderer;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    
    
    void Start(){
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update(){
        if (TopDownManager.Instance.state != TopDownManager.GameState.Playing) return;

        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0)){
            if (Time.time > nextFire){
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
        
        Vector2 lookDir = _mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90){
            _spriteRenderer.flipY = true;
        } else {
            _spriteRenderer.flipY = false;
        }
        
    }

    private void Shoot(){
        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletTD>().SetDirection((_mousePos - (Vector2)transform.position).normalized);
        AudioManager.instance.AddToAudioQueue(3);
    }
}
