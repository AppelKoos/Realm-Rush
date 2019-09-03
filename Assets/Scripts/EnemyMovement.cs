using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyDamage enemyChild;
    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            if (enemyChild.GetIsDead())
            {
                print("Child dead, destroying self");
                Destroy(gameObject);
                break;
            }
            else
            {
                transform.position = waypoint.transform.position;
                yield return new WaitForSeconds(2f);
            }  
        }
    }
}
