using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 100f;
    public Transform playerCamera;
    public Light flashlight;
    private bool key1 = false;
    private bool key2 = false;
    private bool plantBomb = false;
    private bool bombPlanted = false;

    private bool isDoorOpen = false;
    private float bombTimer = 0f;
    private bool timerActive = false;
    private float xRotation = 0f;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
        if (Input.GetKeyDown(KeyCode.B) && plantBomb == true)
        {
            plantBomb = false;
            bombPlanted = true;
            timerActive = true;
            bombTimer = 10f;
        }
        if (timerActive)
        {
            bombTimer -= Time.deltaTime;

            if (bombTimer <= 0)
            {
                timerActive = false;
                SceneManager.LoadScene("Menu");
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("door")  && !isDoorOpen )
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            if (anim != null)
            {
                anim.Play("openDoor_" + collision.gameObject.name);
                //isDoorOpen = true;
            }
        }
        if (collision.gameObject.name == "key1")
        {
            key1 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "key2")
        {
            key2 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("closedDoor") && key2 == true)
        {
            Animator doorAnim = collision.gameObject.GetComponent<Animator>();
            if (doorAnim != null)
            {
                doorAnim.Play("openDoor_" + collision.gameObject.name);
            }
        }
         if (collision.gameObject.name == "ExitDoor" && key1 == true && bombPlanted == true )
        {
            SceneManager.LoadScene("Menu");
        }
    }
    /*void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("door") && isDoorOpen)
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            string animName = "closeDoor_" + collision.gameObject.name;
            anim.Play(animName);
            isDoorOpen = false;
        }
    }*/
    void OnTriggerStay(Collider other)
    {
         if (other.gameObject.name == "BombZone")
        {
            plantBomb = true;
        }
    }
    void OnGUI()
    {
        if (plantBomb && !bombPlanted)
        {
            GUI.Label(new Rect(10, 50, 100, 50), "Press B to plant bomb!");
        }

        if (bombPlanted && plantBomb)
        {
            GUI.Label(new Rect(10, 50, 100, 50), "You are gay!");
        }
        if (timerActive)
        {
            GUI.Label(new Rect(10, 10, 200, 30), "Bomb Timer: " + Mathf.Ceil(bombTimer).ToString());
        }
            if (key1)
            {
             GUI.Label(new Rect(10, 80, 100, 20), "Key 1: ✓");
            }
            if (key2)
            {
             GUI.Label(new Rect(10, 100, 100, 20), "Key 2: ✓");
            }
    }
}
