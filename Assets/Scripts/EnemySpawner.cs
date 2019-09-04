using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBetweenSpawn = 2.0f;
    [SerializeField] Transform enemyParent;

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        while(true){
            var newEnemy = Instantiate(enemy, new Vector3(0,2,-10), Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
