using Unity.Mathematics;
using UnityEngine;

public class TireSpawn : MonoBehaviour
{

    public Rigidbody tire;

    public float timer = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(tire,transform.position,quaternion.identity);
            timer = 3f;
        }
    }
}
