using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] EnemyDamage enemyChild;
    [SerializeField] ParticleSystem goalParticlePrefab;

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
                transform.position = waypoint.transform.position;
                yield return new WaitForSeconds(moveSpeed);
        }
        CommitDie();
    }
    private void CommitDie()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}
