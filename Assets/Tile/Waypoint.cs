using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    
    private void OnMouseDown()
    {
        if (!isPlaceable)
            return;
        
        Debug.Log(transform.name);
    }
}