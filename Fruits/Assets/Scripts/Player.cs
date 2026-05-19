using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    private bool isGround = true;

    private Rigidbody player;

    private float jumpForce = 5f;

    public static int apples = 0;

    public static int lives = 3;

    public static float kg = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Time.deltaTime * speed,0,0);

        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        if(lives == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void Jump()
    {
        player.AddForce(transform.up * jumpForce,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Tire"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isGround = false;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,150,50), "Apples: " + apples);
        GUI.Label(new Rect(10,25,150,50), "Lives: " + lives);
        GUI.Label(new Rect(10,35,150,50), "Kg collected: " + kg);
    }
}
