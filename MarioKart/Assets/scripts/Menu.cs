using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        GameController.laps = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnGUI()
    {
        
        if(GUI.Button(new Rect(Screen.width/2 - 75 , Screen.height/2 - 25 ,150 , 30), "START"))
        {
            SceneManager.LoadScene("Track1");

        }

        if(GUI.Button(new Rect(Screen.width/2 - 75 , Screen.height/2 + 25  ,150 , 30), "EXIT"))
        {
            Application.Quit();

        }

    }
}
