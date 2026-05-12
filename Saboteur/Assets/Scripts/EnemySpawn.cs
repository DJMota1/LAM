using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float timer = 0f;
    public GameObject enemy;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
