using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
{
    //MovementPlayer.vidas = 3;
}

    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 150, 50), "Start"))
        {
            SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(x, y + 75, 150, 50), "Exit"))
        {
            Application.Quit();
        }
    }
}
