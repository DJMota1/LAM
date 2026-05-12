using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10f;
    public float jumpForce = 5f;
    public static int apples = 0;
    public Transform groundCheck;            
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Rigidbody rb; 
    bool isGrounded; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);
         /*isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        */

        if (Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            PlayerMovement.apples++;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 150), "Apples= " + apples);
    }
}
