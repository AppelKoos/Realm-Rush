using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] BoxCollider enemyCollider;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
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
            var vfx = Instantiate(deathParticlePrefab,transform.position,Quaternion.identity);
            vfx.Play();
            Destroy(gameObject);
            Destroy(vfx);
        }
    }
}
