using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public string firePointName = "FirePoint2";
    public float detectionRange = 1f;
    public float fireRate = 1f;
    public float bulletSpeed = 10f;

    Transform playerTransform;
    Transform firePoint;
    float nextFireTime;

    void Awake()
    {
        var playerGO = GameObject.FindWithTag("Player");
        if (playerGO != null)
            playerTransform = playerGO.transform;

        firePoint = transform.Find(firePointName);
    }
    void Update()
    {
        if (playerTransform == null || firePoint == null || bulletPrefab == null)
            return;

        float dist = Vector3.Distance(transform.position, playerTransform.position);
        if (dist > detectionRange)
            return;

        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Fire()
    {
       Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}



