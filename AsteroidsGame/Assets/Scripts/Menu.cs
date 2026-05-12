using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void OnGUI()
    {
        float width = Screen.width / 2 - 50;
        float height = Screen.height / 2 - 25;
        if(GUI.Button(new Rect(width,height,100,50),"Start Game"))
        {
            Spaceship.energy = 100;
            SceneManager.LoadScene("Game");
        }
        if(GUI.Button(new Rect(width,height + 75,100,50),"Exit"))
        {
            Application.Quit();
        }
    }
}