using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;

    private Vector3 spawn;
    private int enemyIndex;
    private int spawnIndex;

    public Transform target;
    public float enemySpeed;
    public Vector3 rotation;

    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while(true)
        {  
            yield return new WaitForSeconds(4f);
            spawnIndex = Random.Range(0,8);
            enemyIndex = Random.Range(0,9);
            spawn = spawnPoint[spawnIndex].position + new Vector3(0,Random.Range(-40,40),0);

            Instantiate(enemy[enemyIndex], spawn, Quaternion.identity);
        }
    }
}
