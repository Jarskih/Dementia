using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Waypoint _currentWaypoint;
    private SpriteRenderer _renderer;

    private Waypoints _waypoints;
    // Start is called before the first frame update
    void Start()
    {
        _waypoints = FindObjectOfType<Waypoints>();
       _currentWaypoint = _waypoints.GetFirstWaypoint();
       _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, _currentWaypoint.transform.position);

        if (distance < 0.5f)
        {
            _currentWaypoint = _waypoints.GetNextWayPoint(_currentWaypoint.index);
        }

        var lookDir = _currentWaypoint.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(lookDir.normalized, Vector3.forward);
        var rot = Quaternion.RotateTowards(_renderer.transform.rotation, lookAt, 30f);
        rot.y = 0;
        rot.x = 0;

        _renderer.transform.rotation = rot;
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.transform.position, 0.1f);
    }
}
