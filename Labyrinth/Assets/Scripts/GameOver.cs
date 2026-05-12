using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float timer = 3f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SceneManager.LoadScene("Menu");  
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 48;
        style.normal.textColor = Color.red;
        style.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(0, Screen.height / 2 - 50, Screen.width, 100), "Game Over", style);
    }
}

