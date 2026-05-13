
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    public float mouseSensitivity = 100f;
    private int ammo = 0;
    private float xRotation = 0f;
    private bool key = false;
    public GameObject bullet;
    public Transform firepoint;
    public Transform playerCamera;
    public Animator anim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 move = transform.right * hor + transform.forward * vert;
        transform.position += move;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Space) && ammo != 0)
        {
            GameObject clone = Instantiate(bullet, firepoint.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(firepoint.right * 7f, ForceMode.Impulse);
            ammo--;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AmmoBox")
        {
            Destroy(other.gameObject);
            ammo = 6;
        }
        if (other.gameObject.name == "key(Clone)")
        {
            Destroy(other.gameObject);
            key = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Door" && Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("door");
        }
         if (other.gameObject.name == "ExitDoor" && key && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Guard")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
