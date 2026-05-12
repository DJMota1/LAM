using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Player.pontos = 0;
    }
    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 100, 50), "Start"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (GUI.Button(new Rect(x, y + 75, 100, 50), "Quit"))
        {
            Application.Quit();
        }
        
    }
}
