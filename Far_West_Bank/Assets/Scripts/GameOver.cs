using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 100, 200, 30), "Game Over");

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 150, 100, 40), "Try Again"))
        {
            SceneManager.LoadScene("Game");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 200, 100, 40), "Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

