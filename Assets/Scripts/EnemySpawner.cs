using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBetweenSpawn = 2.0f;
    private void Start()
    {
        StartCoroutine(spawnEnemy());
        
    }
    IEnumerator spawnEnemy()
    {
        while(true){
            print("spawner called");
            Instantiate(enemy, transform.localPosition, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
