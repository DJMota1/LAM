using Unity.Mathematics;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private float speed = 10.0f;
    public Rigidbody bullet;
    public static int energy = 100;
    public Transform firepoint;

    private AudioSource audio;

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(-vertical * speed * Time.deltaTime, 0, horizontal * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            energy--;
            Rigidbody clone = Instantiate(bullet, firepoint.position, Quaternion.Euler(0,0,90));
            clone.AddForce(transform.forward * speed,ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("BarrelRoll");
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            energy -= 40;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Battery"))
        {
            energy+=40;
            Destroy(collision.gameObject);
        }

    }
}
