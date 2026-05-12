using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime,0,0);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "DestructionPoint")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}