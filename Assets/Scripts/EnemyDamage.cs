using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] BoxCollider enemyCollider;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private int enemiesKilled = 0;

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }
    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
    private void KillEnemy()
    {
        if (hitPoints < 0)
        {
            enemiesKilled++;
            var vfx = Instantiate(deathParticlePrefab,transform.position,Quaternion.identity);
            vfx.Play();
            float destroyDelay = vfx.main.duration;
            Destroy(vfx.gameObject, destroyDelay);
            Destroy(gameObject);
        }
    }
}
