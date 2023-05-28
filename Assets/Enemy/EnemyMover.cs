using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new();
    [SerializeField] [Range(0f, 5f)] private float enemySpeed = 1f;
    private Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        const string pathTagName = "Path";
        
        path.Clear();
        var pathObj = GameObject.FindGameObjectWithTag(pathTagName);

        foreach (Transform tileTransform in pathObj.transform)
        {
            Waypoint tile = tileTransform.GetComponent<Waypoint>();
            if (tile != null)
                path.Add(tile);
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            var startPosition = transform.position;
            var endPosition = waypoint.transform.position;
            var travelPercent = 0f;

            transform.LookAt(endPosition);
            
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        
        FinishPath();
    }
}