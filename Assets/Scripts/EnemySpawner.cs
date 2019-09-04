using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyDamage enemy;
    [SerializeField] Text enemiesSpawnText;
    [SerializeField] float timeBetweenSpawn = 2.0f;
    [SerializeField] Transform enemyParent;
    [SerializeField] AudioClip enemySpawnedSound;

    private int enemiesSpawned = 0, enemiesKilled = 0;

    private void Start()
    {
        enemiesSpawnText.text = "0 / 0";
        StartCoroutine(spawnEnemy());
    }

    private void Update()
    {
        if (enemy.GetStatus())
        {
            enemiesKilled++;
        }
        enemiesSpawnText.text =  enemiesKilled.ToString() + " / " + enemiesSpawned.ToString();
    }

    IEnumerator spawnEnemy()
    {
        while(true){
            GetComponent<AudioSource>().PlayOneShot(enemySpawnedSound); 
            var newEnemy = Instantiate(enemy, new Vector3(0,2,-10), Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            enemiesSpawned++;
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
