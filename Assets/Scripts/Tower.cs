using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public PlaceTowers towerBase;

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    
    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            LookAtTarget();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }
    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(transformA.position, transformB.position);
        float distToB = Vector3.Distance(transformB.position, transformA.position);
        if (distToA < distToB)
        {
            return transformA;
        }
            return transformB;
    }
    private void LookAtTarget()
    { objectToPan.LookAt(targetEnemy); }
    private void FireAtEnemy()
    {
        float rangeToTarget = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (rangeToTarget <= attackRange)
        {
            Shoot(true);
        }
        else
        { Shoot(false); }
    }
    private void Shoot(bool isShooting)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isShooting;
    }
}
