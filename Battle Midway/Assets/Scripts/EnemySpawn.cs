using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public bool spawnEnemies = true;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame

 IEnumerator SpawnRoutine()
    {
        Vector3 spawnPos = Vector3.zero;

        while (spawnEnemies)
        {
 
            yield return new WaitForSeconds(2f);


            spawnPos.x = Random.Range(-10.0f, 10.0f);
            spawnPos.y = 1.0f;
            spawnPos.z = 6.5f;


            Instantiate(enemy, spawnPos ,Quaternion.Euler(0f, 180f, 0f)) ;

        }
    }
    
}
