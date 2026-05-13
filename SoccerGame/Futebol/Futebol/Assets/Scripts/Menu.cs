using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50,Screen.height / 2 - 75, 150, 50), "Start Game"))
        {
            SceneManager.LoadScene("Game");   
        }
            
        if (GUI.Button(new Rect(Screen.width / 2 - 50,Screen.height / 2, 150, 50), "Exit Game"))
        {
            Application.Quit();  
        }
    }
}