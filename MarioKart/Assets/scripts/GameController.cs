using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
public class GameController : MonoBehaviour
{
    public static int laps = 0;
    public int position = 4;
    public GameObject playerPrefab;
    public GameObject[] npcPrefabs;
    public Transform[] gridPositions;
    public Transform[] waypoints;
    public Transform finishLine;

    public bool playerWin = false;
    public bool npcWin = false;

    private String npcName;
    private float timer = 5f;

    private List<GameObject> racers = new List<GameObject>();
    void Start()
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < gridPositions.Length; i++)
            indexes.Add(i);

        for (int i = indexes.Count - 1; i > 0; i--)
        {
            int r = UnityEngine.Random.Range(0, i + 1);
            int temp = indexes[i];
            indexes[i] = indexes[r];
            indexes[r] = temp;
        }

        GameObject player = Instantiate(playerPrefab, gridPositions[indexes[0]].position, gridPositions[indexes[0]].rotation);
        Player playerScript = player.GetComponent<Player>();
        playerScript.playerWaypoints = waypoints;
        racers.Add(player);

        for (int i = 0; i < npcPrefabs.Length; i++)
        {
            int gridIndex = indexes[i + 1];
            GameObject npc = Instantiate(npcPrefabs[i], gridPositions[gridIndex].position, gridPositions[gridIndex].rotation);

            Npc npcScript = npc.GetComponent<Npc>();
            npcScript.waypoints = waypoints;
            npcScript.finishLine = finishLine;
            racers.Add(npc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePositions();
        if (laps >= 3)
        {
            playerWin = true;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        for (int i = 0; i < racers.Count; i++)
        {
            if (racers[i].CompareTag("Player")) continue;

            Npc npcScript = racers[i].GetComponent<Npc>();
            if (npcScript != null && npcScript.raceFinished && !playerWin)
            {
                npcWin = true;
                npcName = racers[i].gameObject.name;
                timer -= Time.deltaTime;
                if (timer <= 0)
                    SceneManager.LoadScene("Menu");
            }
        }

    }

    void CalculatePositions()
    {
        racers.Sort((a, b) =>
        {
            int lapA = GetLap(a);
            int lapB = GetLap(b);

            if (lapA != lapB)
                return lapB.CompareTo(lapA);

            int wpA = GetWaypoint(a);
            int wpB = GetWaypoint(b);

            if (wpA != wpB)
                return wpB.CompareTo(wpA);

            float distA = GetDistanceToWaypoint(a);
            float distB = GetDistanceToWaypoint(b);

            return distA.CompareTo(distB);
        });

        for (int i = 0; i < racers.Count; i++)
        {
            if (racers[i].CompareTag("Player"))
            {
                position = i + 1;
                break;
            }
        }
    }

    int GetLap(GameObject racer)
    {
        if (racer.CompareTag("Player"))
            return laps;

        return racer.GetComponent<Npc>().currentLap;
    }

    int GetWaypoint(GameObject racer)
    {
        if (racer.CompareTag("Player"))
            return racer.GetComponent<Player>().current;

        return racer.GetComponent<Npc>().currentWaypoint;
    }
    float GetDistanceToWaypoint(GameObject racer)
    {
        int wp;

        if (racer.CompareTag("Player"))
            wp = racer.GetComponent<Player>().current;
        else
            wp = racer.GetComponent<Npc>().currentWaypoint;

        return Vector3.Distance(
            racer.transform.position,
            waypoints[wp].position
        );
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Voltas:" + laps);
        GUI.Label(new Rect(10, 40, 100, 30), "Posicao :" + position + "/4");

        if (playerWin)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 100, 30), "O vencendor é: Player");
        }
        if (npcWin)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 100, 30), "O vencendor é: " + npcName);
        }
    }
}
