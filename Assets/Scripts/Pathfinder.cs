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
    Waypoint searchCenter;
    List<Waypoint> path= new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }
    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint prevouis = endWaypoint.exploredFrom;
        while(prevouis != startWaypoint)
        {
            path.Add(prevouis);
            prevouis = prevouis.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }
    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint){isRunning = false;}  
    }
    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighbourCoords))
            {QueueNewNeighbours(neighbourCoords);}
        }
    }
    private void QueueNewNeighbours(Vector2Int neighbourCoords)
    {
        Waypoint neightbour = grid[neighbourCoords];
        if (neightbour.isExplored || queue.Contains(neightbour))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neightbour);
            neightbour.exploredFrom = searchCenter;
        }
    }
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            { Debug.LogWarning("Skipping overlapping block" + waypoint); }
            else
            { grid.Add(gridPos, waypoint); }
        }
    }
}