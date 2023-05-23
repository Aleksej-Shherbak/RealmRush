using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    [SerializeField] private GameObject towerPrefab;
    
    private void OnMouseDown()
    {
        if (!isPlaceable && towerPrefab != null)
            return;

        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}