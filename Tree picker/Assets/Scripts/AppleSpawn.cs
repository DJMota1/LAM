using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    public GameObject apple;

    public float spawnInterval = 2f;

    float timer;

    void Start()
    {
        timer = 0f; 
    }

    void Update()
    {
        Respawn();
    }
    void Respawn()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-10f, 10f),6f,-3.92f);
            Instantiate(apple, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }
}
