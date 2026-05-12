using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections;

public class GameEnd : MonoBehaviour
{
    public float flashSpeed = 1f;
    public Color flashColor = Color.red;
    public float flashDuration = 3f;

    private TextMeshProUGUI uiText;  

    void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        if (uiText == null)
            Debug.LogError("FlashingGameOver: no TextMeshProUGUI component found!");
    }

    void OnEnable()
    {
        StartCoroutine(FlashAndLoadMenu());
    }

    IEnumerator FlashAndLoadMenu()
    {
        float timer = 0f;

        while (timer < flashDuration)
        {
            float alpha = Mathf.PingPong(Time.time * flashSpeed, 1f);
            uiText.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        uiText.color = new Color(flashColor.r, flashColor.g, flashColor.b, 1f);

        SceneManager.LoadScene("Menu");
    }
}


