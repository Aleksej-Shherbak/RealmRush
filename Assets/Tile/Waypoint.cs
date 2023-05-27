using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    [SerializeField] private Tower towerPrefab;
    public bool IsPlaceable => isPlaceable;

    private void OnMouseDown()
    {
        if (!isPlaceable && towerPrefab != null)
            return;

        var isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        isPlaceable = !isPlaced;
    }
}