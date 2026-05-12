using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float maxDistance = 50f;
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position;
    }
    
    void Update()
    {
        float distance = Vector3.Distance(spawnPosition, transform.position);

        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (collision.gameObject.name == "Floor")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
