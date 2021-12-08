using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color DefaultColor = Color.white;
    [SerializeField] Color BlockedColor = Color.gray;

    TextMeshPro Label;
    Vector2Int coordinate = new Vector2Int();
    Waypoint waypoint;
    void Awake()
    {
        Label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
        Label.enabled = false;
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            Label.enabled = true;
        }
        SetLabelColor();
        ToggleLabels();
    }
    void DisplayCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.z);
        Label.text = coordinate.ToString() ;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }
    void SetLabelColor()
    {
        if(waypoint.IsPlaceable)
        {
            Label.color=DefaultColor;
        }
        else
        {
            Label.color = BlockedColor;
        }
    }
    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Label.enabled = (!Label.enabled);//or !label.isActive();
        }
    }
}
