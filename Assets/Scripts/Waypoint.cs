using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
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
}
