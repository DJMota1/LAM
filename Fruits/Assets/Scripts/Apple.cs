using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float grams;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Player.apples += 1;
            Player.kg += grams/1000;
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Ground")
        {
            Player.lives -= 1;
            Destroy(gameObject);
        }
        
    }
}
