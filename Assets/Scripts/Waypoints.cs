﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] List<Waypoint> _waypoints = new List<Waypoint>();

    private void Start()
    {
        int index = 0;
        foreach (var w in _waypoints)
        {
            w.index = index;
            index++;
        }
    }

    public Waypoint GetNextWayPoint(int index)
    {
        if (index >= _waypoints.Count-1)
        {
            return _waypoints[0];
        }

        return _waypoints[index + 1];
    }

    public Waypoint GetFirstWaypoint()
    {
        return _waypoints[0];
    }
}