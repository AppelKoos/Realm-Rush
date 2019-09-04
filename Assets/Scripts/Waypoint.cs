using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    public bool isExplored = false;

    const int GRIDSIZE = 10;

    Vector2Int gridPos;
   
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
