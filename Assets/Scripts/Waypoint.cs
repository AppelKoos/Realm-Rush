using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    public bool isExplored = false;

    //[SerializeField] Tower towerPrefab;

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
  
    /*private void PlaceTower()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlacable = false;
    }*/
    /*private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                PlaceTower();
                print("Tower placed at " + gameObject.name);
            }
            else
            {
                print("Cannot place at" + gameObject.name);
            }
        }
    }*/
}
