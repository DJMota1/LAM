using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public float speed = 0.5f;
    public float killZ = -12f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, -(speed * Time.deltaTime));
         if (transform.position.z < killZ)
        {
            Destroy(gameObject);
        }
    }

   
}
