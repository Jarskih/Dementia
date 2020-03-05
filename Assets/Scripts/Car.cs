using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _turnRate = 30f;
    [SerializeField] private float _speed = 1f;
    public Waypoint CurrentWaypoint;
    private SpriteRenderer _renderer;
    private DetectCollision _detectCollision;

    public Waypoints Waypoints;

    [SerializeField] bool _collide = true;

    // Start is called before the first frame update
    void Start()
    {
       _renderer = GetComponentInChildren<SpriteRenderer>();
       _detectCollision = GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_collide && _detectCollision.IsColliding())
        {
            return;
        } 
        
        var distance = Vector3.Distance(transform.position, CurrentWaypoint.transform.position);

        if (distance < 0.5f)
        {
            var _next = Waypoints.GetNextWayPoint(CurrentWaypoint.index);
            if (_next != null)
            {
                CurrentWaypoint = _next;
            }
        }

        var lookDir = CurrentWaypoint.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(lookDir.normalized, Vector3.forward);
        var rot = Quaternion.RotateTowards(_renderer.transform.rotation, lookAt, _turnRate);
        rot.y = 0;
        rot.x = 0;

        //_renderer.transform.rotation = rot;
        transform.rotation = rot;
        CurrentWaypoint.transform.position = new Vector3(CurrentWaypoint.transform.position.x, CurrentWaypoint.transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.transform.position, _speed*Time.deltaTime);
    }
}
