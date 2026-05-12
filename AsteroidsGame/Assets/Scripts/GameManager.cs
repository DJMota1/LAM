using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform spawn;
    private int counter = 0;
    private float timer = 0.0f;

    public Rigidbody asteroid;

    public Rigidbody battery;

    private float brTimer = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Spaceship.energy = Mathf.Clamp(Spaceship.energy, 0, 100);
        timer += Time.deltaTime;
        brTimer -= Time.deltaTime;
        if (timer >= 2.0f)
        {
            Vector3 actualSpawn = new Vector3(
                spawn.position.x,
                Random.Range(-7.0f, 7.0f),
                spawn.position.z
            );

            if (counter < 5)
            {
                Instantiate(asteroid, actualSpawn, spawn.rotation);
                counter++;
            }
            else
            {
                Instantiate(battery, actualSpawn, spawn.rotation);
                counter = 0;
            }

            timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Spaceship.energy <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void OnGUI()
    {
        float width = Screen.width / 2 - 50;
        float height = Screen.height / 2 - 25;
        GUI.Label(new Rect(10, 10, 100, 50), "Energy: " + Spaceship.energy);

        if (brTimer >= 0.0f)
        {
            GUI.Label(new Rect(width, height, 100, 50), "Press LSHIFT to do a Barrel Roll!!!");
        }
    }
}
