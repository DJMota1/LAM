using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Transform[] waypoints;

    private Transform targetWaypoint;
    private NavMeshAgent agent;

    private int currentIndex = -1;

    public static bool[] occupiedWaypoints;

    public static bool HasFreeWaypoint()
{
    for (int i = 0; i < occupiedWaypoints.Length; i++)
    {
        if (!occupiedWaypoints[i])
            return true;
    }
    return false;
}

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (occupiedWaypoints == null)
        {
            occupiedWaypoints = new bool[waypoints.Length];
        }

        ChooseFreeWaypoint();
    }

    void ChooseFreeWaypoint()
    {
        List<int> freeIndices = new List<int>();

        for (int i = 0; i < occupiedWaypoints.Length; i++)
        {
            if (occupiedWaypoints[i] == false)
            {
                freeIndices.Add(i);
            }
        }

        int chosenIndex =
            freeIndices[Random.Range(0, freeIndices.Count)];

        occupiedWaypoints[chosenIndex] = true;

        currentIndex = chosenIndex;

        targetWaypoint = waypoints[chosenIndex];

        agent.SetDestination(targetWaypoint.position);
    }

    void OnDestroy()
    {
        if (currentIndex >= 0)
        {
            occupiedWaypoints[currentIndex] = false;
        }
    }
}