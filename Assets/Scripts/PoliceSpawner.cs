using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject officer1;
    [SerializeField] GameObject officer2;

    [SerializeField] private Transform _spawnCar;
    [SerializeField] private Transform _spawnOfficer1;
    [SerializeField] private Transform _spawn3Officer2;
    
    void OnEnable() {
        EventManager.StartListening("Police", SpawnCar);
        EventManager.StartListening("Officers", SpawnOfficers);
    }
    void OnDisable() {
        EventManager.StopListening("Police", SpawnCar);
        EventManager.StopListening("Officers", SpawnOfficers);
    }
    
    private void SpawnCar()
    {
        Instantiate(carPrefab, _spawnCar.position, Quaternion.identity);
    }
    
    
    private void SpawnOfficers()
    {
        Instantiate(officer1, _spawnOfficer1.position, Quaternion.identity);
        Instantiate(officer2, _spawn3Officer2.position, Quaternion.identity);
    }
}
