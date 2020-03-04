using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _radius;
    [SerializeField] private bool _colliding;

    public bool IsColliding()
    {
        return _colliding;
        Debug.DrawRay(transform.position, -transform.up, Color.red, 0.1f);
        
        if (Physics.SphereCast(transform.position, _radius, -transform.up, out var hit, _maxDistance))
        {
            Debug.Log("hit: " + hit.collider);
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _colliding = false;
        }
    }
}
