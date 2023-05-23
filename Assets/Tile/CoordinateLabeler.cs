using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private Vector2Int coordinate;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        // Execute in edit mode only
        if (Application.isPlaying)
            return;

        DisplayCoordinates();
        UpdateObjectName();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }

    void DisplayCoordinates()
    {
        FillCoordinates();
        if (label != null)
        {
            label.text = $"{coordinate.x},{coordinate.y}";
        }
    }

    void FillCoordinates()
    {
        var parentPosition = transform.parent.position;
        coordinate.x = Mathf.RoundToInt(parentPosition.x / EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(parentPosition.z / EditorSnapSettings.move.z);
    }
}