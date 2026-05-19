using UnityEngine;

public class Tire : MonoBehaviour
{
    public float speed = 3f;

    public float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);

        if (transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }
}
