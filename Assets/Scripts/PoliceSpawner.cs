using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;

    [SerializeField] private Transform _spawnCar;

    [SerializeField] private Waypoints _waypoints;

    void OnEnable()
    {
        EventManager.StartListening("Police", SpawnCar);
    }

    void OnDisable()
    {
        EventManager.StopListening("Police", SpawnCar);
    }

    private void SpawnCar()
    {
        var policeCar = Instantiate(carPrefab, _spawnCar.position, Quaternion.identity);
        policeCar.GetComponent<Car>().Waypoints = _waypoints;
        policeCar.GetComponent<Car>().CurrentWaypoint = _waypoints.GetFirstWaypoint();
    }
}
