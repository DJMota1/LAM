using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.position += new Vector3(-(speed * Time.deltaTime), 0, 0);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
