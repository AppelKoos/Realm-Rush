﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Block> path;
    private void Start()
    {
        PrintAllWaypoints();
    }
    private void PrintAllWaypoints()
    {
        foreach (Block waypoint in path)
        {
            print(waypoint.name);
        }
    }
}
