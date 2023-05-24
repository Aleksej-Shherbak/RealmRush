using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    private TextMeshPro label;
    private Vector2Int coordinate;
    private Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        
        if (label != null)
            label.enabled = false;
        
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ToggleLabels();
        ColorCoordinates();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }

    void ColorCoordinates()
    {
        if (waypoint == null)
            return;
        
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        FillCoordinates();
        if (label != null)
            label.text = $"{coordinate.x},{coordinate.y}";
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C) && label != null)
            label.enabled = !label.IsActive();
    }

    void FillCoordinates()
    {
        var parentPosition = transform.parent.position;
        coordinate.x = Mathf.RoundToInt(parentPosition.x / EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(parentPosition.z / EditorSnapSettings.move.z);
    }
}