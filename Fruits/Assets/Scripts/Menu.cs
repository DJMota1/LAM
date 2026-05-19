using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.apples = 0;
        Player.lives = 3;
        Player.kg = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2 - 75,Screen.height / 2 - 50, 200, 50), "START"))
        {
            SceneManager.LoadScene("Game");
        }
        if(GUI.Button(new Rect(Screen.width / 2 - 75,Screen.height / 2 + 25, 200, 50), "EXIT"))
        {
            Application.Quit();
        }
    }
}
