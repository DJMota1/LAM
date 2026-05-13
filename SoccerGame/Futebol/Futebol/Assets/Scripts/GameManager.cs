using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    private int goalsPlayer = 0;
    private int goalsNPC = 0;
    private float timer;
    private Vector3 spawn;
    private Rigidbody rb;

    public void Start()
    {
        spawn = transform.position;
        rb = GetComponent<Rigidbody>();
        timer = 120f;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

   void OnGUI()
{
    int minutes = Mathf.FloorToInt(timer / 60f);
    int seconds = Mathf.FloorToInt(timer % 60f);

    GUI.Label(new Rect(Screen.width / 2, 10, 400, 30),
        "Timer: " + minutes + ":" + seconds.ToString("00") +
        "Score: " + goalsPlayer + ":" + goalsNPC);
}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "GoalZone1")
        {
            rb.linearVelocity = new Vector3(0,0,0);
            transform.position = spawn;
            goalsPlayer++;
            MoveNPC.attackingMode = true;
        }
        if(collision.gameObject.name == "GoalZone2")
        {
            rb.linearVelocity = new Vector3(0,0,0);
            transform.position = spawn;
            goalsNPC++;
            MoveNPC.attackingMode = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerZone")
        {
            MoveNPC.defenderMode = true;
            MoveNPC.attackingMode = false;
        }
         if(other.gameObject.name == "NPCZone")
        {
            MoveNPC.defenderMode = false;
            MoveNPC.attackingMode = true;
        }
    }
}