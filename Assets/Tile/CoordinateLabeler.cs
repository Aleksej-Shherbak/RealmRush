using Pathfinding;
using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f);
    
    
    private TextMeshPro label;
    private Vector2Int coordinates;
    private GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        ToggleLabels();
        SetLabelColor();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetLabelColor()
    {
        if (gridManager == null)
            return;

        var node = gridManager.GetNode(coordinates);
        
        if (node == null)
            return;

        if (!node.isWalkable)
            label.color = blockedColor;
        else if (node.isPath)
            label.color = pathColor;
        else if (node.isExplored)
            label.color = exploredColor;
        else
            label.color = defaultColor;
    }

    void DisplayCoordinates()
    {
        FillCoordinates();
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
            label.enabled = !label.IsActive();
    }

    void FillCoordinates()
    {
        var parentPosition = transform.parent.position;
        coordinates.x = Mathf.RoundToInt(parentPosition.x / EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(parentPosition.z / EditorSnapSettings.move.z);
    }
}