using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int money = 0;

    public Transform[] spawns;
    public GameObject[] npcs; 

    public Animator openLDoor;
    public Animator openMDoor;
    public Animator openRDoor;

    private float timer = 0f;
    private GameObject currentNPC;
    private bool doorOpen = false;
    private bool npcSpawned = false;
    private bool npcShot = false;
    private int currentDoorIndex;

    void Update()
    {
        if (money >= 1000)
        {
            Debug.Log("You win!");
            Time.timeScale = 0;
            SceneManager.LoadScene("Win");
            return;
        }

        timer += Time.deltaTime;

        if (!doorOpen && timer >= 3f)
        {
            currentDoorIndex = Random.Range(0, spawns.Length);
            Animator door = GetDoorAnimator(currentDoorIndex);
            door.Play(GetDoorOpenAnim(currentDoorIndex));

            int npcIndex = Random.Range(0, npcs.Length);
            currentNPC = Instantiate(npcs[npcIndex], spawns[currentDoorIndex].position, Quaternion.identity);

            npcSpawned = true;
            npcShot = false;
            doorOpen = true;
            timer = 0f;
        }

        if (doorOpen && timer >= 2f)
        {
            if (!npcShot && npcSpawned)
            {
                if (currentNPC.CompareTag("Robber"))
                {
                    money = 0;
                    Debug.Log("Robber escaped! You lost all your money.");
                }
                else if (currentNPC.CompareTag("Client"))
                {
                    money += 100;
                    Debug.Log("Client not shot! +$100.");
                }
            }

            Animator door = GetDoorAnimator(currentDoorIndex);
            door.Play(GetDoorCloseAnim(currentDoorIndex));

            if (currentNPC != null)
                Destroy(currentNPC);

            npcSpawned = false;
            doorOpen = false;
            timer = 0f;
        }
    }

    public void OnNPCShot()
    {
        if (!npcShot && currentNPC != null)
        {
            npcShot = true;

            if (currentNPC.CompareTag("Robber"))
            {
                Debug.Log("Robber shot! Good job.");
            }
            else if (currentNPC.CompareTag("Client"))
            {
                Debug.Log("Client shot! That was a mistake.");
                SceneManager.LoadScene("GameOver");
            }

            Destroy(currentNPC);
        }
    }

    Animator GetDoorAnimator(int index)
    {
        if (index == 0) return openLDoor;
        if (index == 1) return openMDoor;
        return openRDoor;
    }

    string GetDoorOpenAnim(int index)
    {
        if (index == 0) return "openLDoor";
        if (index == 1) return "openMDoor";
        return "openRDoor";
    }

    string GetDoorCloseAnim(int index)
    {
        if (index == 0) return "closeLDoor";
        if (index == 1) return "closeMDoor";
        return "closeRDoor";
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Money = " + money);
    }
}

