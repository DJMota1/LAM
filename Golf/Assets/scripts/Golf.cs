using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;


public class Golf : MonoBehaviour
{
    public static int tacadas = 0;
    public float force = 5;
    private Rigidbody rb;
    public float rotationspeed = 30f;
    public float maxForce = 20F;
    private bool isCharging = false;
    private float currentForce = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * rotationspeed * Time.deltaTime, 0);
        if (Input.GetMouseButtonDown(0))
        {
            tacadas +=1;
            if (rb.linearVelocity == Vector3.zero)
            {
                isCharging = true;
                currentForce = force;
            }
        }

        if (isCharging && Input.GetMouseButton(0))
        {
            currentForce += 2f * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0f, maxForce);
        }

        if (isCharging && Input.GetMouseButtonUp(0))
        {
            rb.AddForce(transform.forward * currentForce, ForceMode.Impulse);
            isCharging = false;
        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,30),"Tacadas:"+ tacadas);
    }


}
