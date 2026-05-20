using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bandeira : MonoBehaviour
{
    private float timer =0;
    private bool Ganhou=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        timer=0;
        if (other.CompareTag("bola"))
        {
            Ganhou=true;
            if (timer >= 4f)
            {
                    SceneManager.LoadScene("Track2");
            }
            
            
            


        }

    }
    void OnGUI()
    {
        if (Ganhou)
        {
            GUI.Label(new Rect ( Screen.width / 2 -75 , Screen.height/2 -25 , 100 ,30), "Parabens");
        }


    }
}
