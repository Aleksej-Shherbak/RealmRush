using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _path = new List<Waypoint>();

    void Start()
    {
        PrintWaypointName();
    }

    void PrintWaypointName()
    {
        foreach (var waypoint in _path)
        {
            Debug.Log(waypoint.name);
        }
    }
}