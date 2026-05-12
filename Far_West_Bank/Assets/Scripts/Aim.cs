using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour
{
    float speed = 10.0f;
    public GameManager gameManager;

    public AudioSource audio;

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            Ray ray = new Ray(transform.position, -transform.up)  ;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Client") || hit.collider.CompareTag("Robber"))
                {
                    gameManager.OnNPCShot();
                }
            }
        }
    }
}
