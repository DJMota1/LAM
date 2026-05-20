using UnityEngine;
using UnityEngine.SceneManagement;


public class Buraco : MonoBehaviour
{
    AudioSource audioData;
   
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            Destroy(collision.gameObject);
            GameController.bolasMetidas++;
            audioData.Play();
        }
        
        if (collision.gameObject.CompareTag("BolaPreta") && GameController.bolaPreta)
        {
            audioData.Play();
            SceneManager.LoadScene("Menu");
            
        }
    }
}
