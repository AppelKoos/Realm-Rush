﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor = Color.blue;
    public Waypoint exploredFrom;
    public bool isExpored = false;
    Vector2Int gridPos;
    const int GRIDSIZE = 10;
    private void Update()
    {
        //UpdateColorOnExplore();
    }
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
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("CubeFace1").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    private void UpdateColorOnExplore()
    {
        MeshRenderer topMeshRenderer = transform.Find("CubeFace1").GetComponent<MeshRenderer>();
        if (isExpored)
        {
            topMeshRenderer.material.color = exploredColor;
        }
        else
        {
            topMeshRenderer.material.color = Color.white;
        }
    }

}