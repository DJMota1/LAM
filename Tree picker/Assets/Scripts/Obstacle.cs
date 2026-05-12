using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject ball;

    public float speed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);


    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
