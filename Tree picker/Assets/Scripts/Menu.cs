using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource music;
    bool play;
    bool toggleChange;
    
    void Start()
    {
        play = true;
    }
    void Update()
    {
        if (play == true && toggleChange == true)
        {
            music.Play();
            toggleChange = false;
        }
        if (play == false && toggleChange == true)
        {
            music.Stop();
            toggleChange = false;
        }
    }
    void OnGUI()
    {
        float x = Screen.width / 2 - 75;
        float y = Screen.height / 2 - 25;

        if (GUI.Button(new Rect(x, y, 100, 50), "Start Game"))
        {
            SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(x, y+75, 100, 50), "Exit Game"))
        {
            Application.Quit();
        }
        play = GUI.Toggle(new Rect(10, 10, 100, 30), play, "Play Music");

        if (GUI.changed)
        {
            toggleChange = true;
        }
    }
}
