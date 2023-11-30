using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public bool isSpawning = true;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform[] _spawnPoints;
    private float _spawnInterval = 5f;
    private float timeSinceSpawn = 0f;


    // Update is called once per frame
    void Update()
    {   
        if (!isSpawning) return;

        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= _spawnInterval)
        {
            timeSinceSpawn = 0f;
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_obstaclePrefab, _spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}
