using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    private void Start()
    {
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        print("Start Patrol");
        foreach (Waypoint waypoint in path)
        {
            print("moved to " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("End Patrol");
    }
}
