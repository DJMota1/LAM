using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, 100, 200, 30), "SnookerTuga");

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 150, 100, 40), "Start"))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, 200, 100, 40), "Quit"))
        {
            Application.Quit();
        }
    }
}
