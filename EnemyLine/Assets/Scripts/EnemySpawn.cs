using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawns;
    public Transform[] waypoints;

    public GameObject enemy;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            timer = 0f;

            if (!Enemy.HasFreeWaypoint())
            return;

            int spawnIndex = Random.Range(0, spawns.Length);

            GameObject obj = Instantiate(
                enemy,
                spawns[spawnIndex].position,
                Quaternion.identity
            );

            Enemy enemyScript = obj.GetComponent<Enemy>();

            enemyScript.waypoints = waypoints;
        }
    }
}