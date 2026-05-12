using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3f;
    public GameObject bullet;
    public Transform firePoint;

    private Vector3 direction = Vector3.right;

    private Vector3 rayDirection = Vector3.right;

    private float fireRate = 1f;
    private float nextFireTime = 0f;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 10f))

        {
            if (hit.collider.name == "Player" && Time.deltaTime >= nextFireTime)
            {
                GameObject clone = Instantiate(bullet, firePoint.position, Quaternion.identity);
                clone.GetComponent<Rigidbody>().AddForce(firePoint.right * 10f, ForceMode.Impulse);
                nextFireTime = Time.deltaTime + fireRate;
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("left"))
        {
            direction = Vector3.right;
            rayDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (collision.CompareTag("right"))
        {
            direction = Vector3.left;
            rayDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
