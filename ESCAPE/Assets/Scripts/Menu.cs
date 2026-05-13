using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 150, 50), "START"))
        {
            SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(x, y+75, 150, 50), "EXIT"))
        {
            Application.Quit();
        }
    }
}
