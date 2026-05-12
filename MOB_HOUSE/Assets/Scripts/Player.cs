
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 7f;
    Rigidbody rb;
    public Animator anim;
    bool weapon = false;
    bool key = false;
    bool isGrounded;
    public GameObject bullet;
    public Transform firePoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Vector3 bulletDir = transform.rotation.y == 0 ? Vector3.right : Vector3.left;
        //bullet.GetComponent<Bullet>().direction = bulletDir;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-(speed * Time.deltaTime), 0, 0);
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0f, 0);

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && weapon == true)
        {
            GameObject clone = Instantiate(bullet, firePoint.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(firePoint.right * 10f, ForceMode.Impulse);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "gun")
        {
            Destroy(other.gameObject);
            weapon = true;
        }
        if (other.gameObject.name == "key")
        {
            Destroy(other.gameObject);
            key = true;
        }

        if (other.gameObject.name == "EndZone")
        {
            SceneManager.LoadScene("Menu");
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.name == "door" && key == true)
        {
            anim.Play("open");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

}
