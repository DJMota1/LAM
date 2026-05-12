using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 200, 100), "Start"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (GUI.Button(new Rect(x, y + 75, 200, 100), "Exit"))
        {
            Application.Quit();
        }
    }
}
