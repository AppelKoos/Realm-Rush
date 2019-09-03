using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    

    void Update()
    {
        if (targetEnemy)
        { FireAtEnemy(); }
        else
        { Shoot(false); }
    }
    private void LookAtTarget()
    {
        objectToPan.LookAt(targetEnemy);
    }
    private void FireAtEnemy()
    {
        float rangeToTarget = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (rangeToTarget <= attackRange)
        {
            LookAtTarget();
            Shoot(true);
        }
        else
        { Shoot(false); }
    }
    private void Shoot(bool isShotting)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isShotting;
    }
}
