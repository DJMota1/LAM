
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 75f;
    public float xRotation = 0f;
    public Transform playerCamera;
    public Light light;
    public float timer = 60f;
    private bool key2 = false;
    private bool key1 = false;
    public AudioSource keyAudio;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, y);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            light.enabled = false;
            SceneManager.LoadScene("Menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "key1")
        {
            keyAudio.Play();
            key1 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "key2")
        {
            keyAudio.Play();
            key2 = true;
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("open");
        }
        if (collision.gameObject.name == "ClosedDoor" && key1)
        {
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("open");
        }
        if (collision.gameObject.name == "ExitDoor" && key2)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("open");
        }
         if (collision.gameObject.name == "EndZone")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 50), "Time left: " + Mathf.Ceil(timer));

        if (key1)
        {
            GUI.Label(new Rect(10, 50, 150, 50), "You have key 1");
        }
        if (key2)
        {
            GUI.Label(new Rect(10, 100, 150, 50), "You have key 2");
        }
    }
}