using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 4.0f;
    public AudioClip explosionSound;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
   void OnCollisionEnter(Collision col)
{
    if (col.gameObject.CompareTag("Enemy"))
    {
        MovementPlayer.pontos += 10;
        Destroy(col.gameObject);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        return;
    }

    if (col.gameObject.CompareTag("Player"))
    {
        MovementPlayer.vidas = Mathf.Max(0, MovementPlayer.vidas - 1);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(gameObject);

        if (MovementPlayer.vidas <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            MovementPlayer player = col.gameObject.GetComponent<MovementPlayer>();
            if (player != null)
            {
                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.position = player.spawnPoint;
                rb.rotation = Quaternion.identity;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        return;
    }
}

      void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
}
