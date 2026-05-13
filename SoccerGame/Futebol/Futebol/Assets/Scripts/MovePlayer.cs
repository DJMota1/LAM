using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform targetBall;
    public Rigidbody rigidbodyBall;
    public float speed = 5f;
    public float rotationSpeed = 360f;
    private float kickForce = 20f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       float rotation = Input.GetAxis("Vertical");
       float movement = Input.GetAxis("Horizontal");

       transform.Translate(0,0,-movement * speed * Time.deltaTime);
       transform.Rotate(0,rotation * rotationSpeed * Time.deltaTime,0);

       if (Vector3.Distance(targetBall.position,transform.position) < 2f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KickBall();
            }
        }
    }
    void KickBall()
    {
        rigidbodyBall.AddForce(transform.forward * kickForce,ForceMode.Impulse);
    }
}

