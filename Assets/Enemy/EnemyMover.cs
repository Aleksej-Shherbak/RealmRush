using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] private float enemySpeed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            MakeStep(waypoint);
            yield return new WaitForSeconds(enemySpeed);
        }
    }

    void MakeStep(Waypoint waypoint)
    {
        transform.position = waypoint.transform.position;
    }
}