using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] BoxCollider enemyCollider;
    bool isDead = false;
   
    public bool GetIsDead()
    { return isDead; }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
        print("Health " + hitPoints);
    }
    private void ProcessHit()
    { hitPoints = hitPoints - 1; }
    private void KillEnemy()
    {
        if (hitPoints < 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
