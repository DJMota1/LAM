using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;
        if (GUI.Button(new Rect(x, y, 100, 50), "START"))
        {
            SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(x, y + 75, 100, 50), "QUIT"))
        {
            Application.Quit();
        }
        
    }
}
