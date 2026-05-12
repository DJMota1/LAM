using UnityEngine;
using UnityEngine.SceneManagement;
public class MovementPlayer : MonoBehaviour
{
    float speed = 5.0f;
    public static int vidas = 3;
    public static int pontos = 0;

    public Vector3 spawnPoint;
    Rigidbody rb;

   public AudioClip explosionSound; 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
                       | RigidbodyConstraints.FreezeRotationZ 
                       | RigidbodyConstraints.FreezePositionY;
    }

    void Start()
    {
        spawnPoint = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);

    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 150), "Pontos= " + pontos);
        GUI.Label(new Rect(10, 25, 300, 150), "Vidas= " + vidas);
    }
    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Enemy")) return;

        vidas--;
        Destroy(col.gameObject);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        

        if (vidas <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Respawn();
        }
    }
    void Respawn()
    {
        rb.position = spawnPoint;
        rb.rotation = Quaternion.identity;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }
}
