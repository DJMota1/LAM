using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 10f;
    public float deceleration = 5f;

    public float rotationSpeed = 150f;
    public float minSpeedToTurn = 5f;

    private float currentSpeed = 0f;

    public Transform[] playerWaypoints;

    public int current = 0;

    public int counter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        float maxSpeedMS = maxSpeed / 3.6f;

        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 2f);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeedMS, maxSpeedMS);

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (Mathf.Abs(currentSpeed) > minSpeedToTurn)
        {
            float speedFactor = currentSpeed / maxSpeedMS; // vai de 0 a 1
            float turnAmount = turnInput * rotationSpeed * speedFactor;

            transform.Rotate(Vector3.up * turnAmount * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, playerWaypoints[current].position) < 5f)
        {
            current++;
            counter++;

            if (current >= playerWaypoints.Length)
            {
                current = 0;
            }
        }
    }
}