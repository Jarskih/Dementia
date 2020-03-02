using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCar : MonoBehaviour
{
    public GameObject carPrefab;

    private float _spawnTimer;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _minSpawnTime = 3;
    [SerializeField] private float _maxSpawnTime = 6;
    
    [SerializeField] private int _maxCars;
    private int _cars;

    private void Start()
    {
        _spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cars >= _maxCars)
        {
            return;
        }
        
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > _spawnTime)
        {
            _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime + 1);
            _spawnTimer = 0;
            _cars += 1;
            var car = Instantiate(carPrefab, transform.position, Quaternion.identity);
            car.transform.localScale = Vector3.one;
            car.transform.SetParent(transform);
        }
    }
}
