using UnityEngine;

public class Meta : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<Player>().counter == 4)
            {
                GameController.laps +=1;
                Debug.Log("Passou na Meta ");
                other.gameObject.GetComponent<Player>().counter = 0;
            }
        }


    }
}
