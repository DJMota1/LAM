using UnityEngine;

public class TacoController : MonoBehaviour
{
    public Rigidbody bola;

    public bool isCharging;

    public float force = 2f;
    public float currentForce = 0f;
    public float chargeSpeed = 5f;

    public float maxForce = 20f;
    public float finalForce = 0f;

    public float rotationSpeed = 60f;

    public Vector3 spawn;
    AudioSource audioData;

    void Start()
    {
        bola = GetComponent<Rigidbody>();
        spawn = transform.position;
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");

        transform.Rotate(0, h * rotationSpeed * Time.deltaTime, 0);


        if (Input.GetMouseButtonDown(0))
        {
            if (bola.linearVelocity == Vector3.zero)
            {
                isCharging = true;
                currentForce = force;
            }
        }


        if (isCharging && Input.GetMouseButton(0))
        {
            currentForce += chargeSpeed * Time.deltaTime;

            currentForce = Mathf.Clamp(currentForce, 0f, maxForce);
        }


        if (isCharging && Input.GetMouseButtonUp(0))
        {
            bola.AddForce(transform.forward * currentForce, ForceMode.Impulse);

            isCharging = false;
            audioData.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Buraco"))
        {
            transform.position = spawn;

            bola.linearVelocity = Vector3.zero;
            bola.angularVelocity = Vector3.zero;
        }


        if (collision.gameObject.CompareTag("BolaPreta") && GameController.bolaPreta == false)
        {
            transform.position = spawn;

            bola.linearVelocity = Vector3.zero;
            bola.angularVelocity = Vector3.zero;
        }
    }
}