using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _turnRate = 30f;
    [SerializeField] private float _speed = 0.1f;
    private Waypoint _currentWaypoint;
    private SpriteRenderer _renderer;
    private DetectCollision _detectCollision;

    private Waypoints _waypoints;
    // Start is called before the first frame update
    void Start()
    {
        _waypoints = FindObjectOfType<Waypoints>();
       _currentWaypoint = _waypoints.GetFirstWaypoint();
       _renderer = GetComponentInChildren<SpriteRenderer>();
       _detectCollision = GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_detectCollision.IsColliding())
        {
            return;
        } 
        
        var distance = Vector3.Distance(transform.position, _currentWaypoint.transform.position);

        if (distance < 0.5f)
        {
            _currentWaypoint = _waypoints.GetNextWayPoint(_currentWaypoint.index);
        }

        var lookDir = _currentWaypoint.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(lookDir.normalized, Vector3.forward);
        var rot = Quaternion.RotateTowards(_renderer.transform.rotation, lookAt, _turnRate);
        rot.y = 0;
        rot.x = 0;

        //_renderer.transform.rotation = rot;
        transform.rotation = rot;
        _currentWaypoint.transform.position = new Vector3(_currentWaypoint.transform.position.x, _currentWaypoint.transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.transform.position, _speed);
    }
}
