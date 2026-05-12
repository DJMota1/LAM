using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bomb;

    private bool hasDroppedBomb = false;
    void Update()
    {
        transform.position += new Vector3(0, 0, -(speed * Time.deltaTime));
        if (transform.position.z <= -5f && !hasDroppedBomb)
        {
            Transform dropBomb = gameObject.GetComponentInChildren<Transform>();
            GameObject newBomb = Instantiate(bomb, dropBomb.position, Quaternion.identity);
            Physics.IgnoreCollision(newBomb.GetComponent<Collider>(), GetComponent<Collider>());
            hasDroppedBomb = true;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Player.pontos += 500;
        }
    }
}
