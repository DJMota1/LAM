using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 100, 200, 30), "You Win!");

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 150, 100, 40), "Play Again"))
        {
            SceneManager.LoadScene("Game");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 200, 100, 40), "Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

