using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] BoxCollider enemyCollider;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDeathSound, enemyHitSound;

    bool isDead = false;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }
    private void ProcessHit()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyHitSound);
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
    private void KillEnemy()
    {
        if (hitPoints < 0)
        {
            PlayVFX();
            AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

    public bool GetStatus()
    {
        return isDead;
    }

    private void PlayVFX()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
    }
}
