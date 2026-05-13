using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject enemy;
    private float timer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            int index = Random.Range(0, spawns.Length);
            Instantiate(enemy, spawns[index].position, Quaternion.identity);
        }
    }
}
