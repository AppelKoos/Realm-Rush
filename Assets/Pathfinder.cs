using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue <Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();   
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from "+searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExpored = true;
        }
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("searching from end node");
            isRunning = false;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoords);
            }
            catch
            {
            }  
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoords)
    {
        Waypoint neightbour = grid[neighbourCoords];
        if (!neightbour.isExpored)
        {
            neightbour.SetTopColor(Color.blue);
            queue.Enqueue(neightbour);
            print("Queing" + neightbour);
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverLaping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverLaping)
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print("Loaded " + grid.Count + " Blocks");
    }
}

