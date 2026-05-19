using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 5f * Time.deltaTime);

        if (transform.position.z >= 15)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "ClosedDoor")
        {
            Destroy(gameObject);
        }
         if (collision.gameObject.name == "Door")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
         if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
