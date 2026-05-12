using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer  >= 3f)
        {
            Vector3 spawn = new Vector3(Random.Range(-7f,7f),10f,20f);
            Instantiate(enemy, spawn, Quaternion.Euler(-90f, 0f, 180f));
            timer = 0f;
        }
    }
}
