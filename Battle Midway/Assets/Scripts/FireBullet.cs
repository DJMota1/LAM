using UnityEngine;

public class FireBullet : MonoBehaviour
{
 public GameObject projectile;

 public Transform gunPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
