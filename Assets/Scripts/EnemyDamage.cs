using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] BoxCollider enemyCollider;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }
    private void ProcessHit()
    { hitPoints = hitPoints - 1; }
    private void KillEnemy()
    {
        if (hitPoints < 0)
        {
            print("EnemyKilled");
            Destroy(gameObject);
        }
    }
}
