using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public float speed = 5f;

   
   // public Vector3 direction;

   /* void Update()
    {
         transform.position += direction * speed * Time.deltaTime;
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
