using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
{
    MovementPlayer.vidas = 3;
    MovementPlayer.pontos = 0;
}

    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 300, 150), "Start"))
        {
            SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(x, y + 75, 300, 150), "Exit"))
        {
            Application.Quit();
        }
    }
}
