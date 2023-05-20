using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    private TextMeshPro _label;
    private Vector2Int _coordinate;

    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
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
        transform.parent.name = _coordinate.ToString();
    }

    void DisplayCoordinates()
    {
        FillCoordinates();
        
        _label.text = $"{_coordinate.x},{_coordinate.y}";
    }

    void FillCoordinates()
    {
        var parentPosition = transform.parent.position;
        _coordinate.x = Mathf.RoundToInt(parentPosition.x / EditorSnapSettings.move.x);
        _coordinate.y = Mathf.RoundToInt(parentPosition.z / EditorSnapSettings.move.z);
    }
}