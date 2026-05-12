using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject ball;

    public float spawnInterval = 2f;

    float timer;

    void Start()
    {
        timer = 0f; 
    }

    void Update()
    {
        RespawnO();
    }
    void RespawnO()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Instantiate(ball, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
