using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Text enemiesSpawnText;
    [SerializeField] float timeBetweenSpawn = 2.0f;
    [SerializeField] Transform enemyParent;
    [SerializeField] EnemyDamage enemyKilled;

    private int enemiesSpawned = 0, enemiesKill = 0;

    private void UpdatEnemiesSpawned()
    {
        enemiesSpawned++;
        enemiesSpawnText.text = enemyKilled.GetEnemiesKilled().ToString() + " / " + enemiesSpawned.ToString();
    }

    private void Start()
    {
        enemiesSpawnText.text = "0 / 0";
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        while(true){
            var newEnemy = Instantiate(enemy, new Vector3(0,2,-10), Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            UpdatEnemiesSpawned();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
