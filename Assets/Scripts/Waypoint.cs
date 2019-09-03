using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor = Color.blue;
    public Waypoint exploredFrom;
    public bool isExplored = false;
    Vector2Int gridPos;
    const int GRIDSIZE = 10;
    public int GetGridSize()
    {
        return GRIDSIZE;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GRIDSIZE),
            Mathf.RoundToInt(transform.position.z / GRIDSIZE)
        );
    }
    private void UpdateColorOnExplore()
    {
        MeshRenderer topMeshRenderer = transform.Find("CubeFace1").GetComponent<MeshRenderer>();
        if (isExplored)
        {
            topMeshRenderer.material.color = exploredColor;
        }
        else
        {
            topMeshRenderer.material.color = Color.white;
        }
    }
    private void OnMouseOver()
    {
        print("Mouse over " + gameObject.name);
    }
}
