using UnityEngine;
using UnityEngine.Experimental.Animations;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 50f;
    public float verticalSpeed = 30f;
    private float currentVerticalAngle = 0f;

    public Transform firePoint;
    public GameObject bullet;

    public static int pontos;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0f, horizontal * horizontalSpeed * Time.deltaTime, 0f, Space.World);

        currentVerticalAngle -= vertical * verticalSpeed * Time.deltaTime;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -45, 20);

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = currentVerticalAngle;
        transform.localEulerAngles = new Vector3(currentVerticalAngle, currentRotation.y, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            GameObject other = Instantiate(bullet, firePoint.position, Quaternion.identity);
            other.GetComponent<Rigidbody>().AddForce(firePoint.forward * 50f, ForceMode.Impulse);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(15, 20, 100, 50), "Pontos: " + pontos);
    }
}
