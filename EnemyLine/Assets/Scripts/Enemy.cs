using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public Transform [] waypoints;
    private Transform targetWaypoint;
    private NavMeshAgent agent;
    private bool isAtWaypoint = false;
    private int currentIndex = -1;

    private static HashSet<int> occupiedWaypoints = new HashSet<int>();

    public float stopDistance = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChooseFreeWaypoint();
    }

    void Update()
    {
        if (isAtWaypoint || targetWaypoint == null)
            return;

        if (!agent.pathPending && agent.remainingDistance <= stopDistance)
        {
            isAtWaypoint = true;
            agent.isStopped = true;
        }
    }

    void ChooseFreeWaypoint()
    {
        List<int> freeIndices = new List<int>();

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (!occupiedWaypoints.Contains(i))
                freeIndices.Add(i);
        }

        if (freeIndices.Count == 0)
        {
            return;
        }

        int chosenIndex = freeIndices[Random.Range(0, freeIndices.Count)];
        occupiedWaypoints.Add(chosenIndex);
        currentIndex = chosenIndex;

        targetWaypoint = waypoints[chosenIndex];
        agent.SetDestination(targetWaypoint.position);
        agent.isStopped = false;
        isAtWaypoint = false;
    }

    void OnDestroy()
    {
        if (currentIndex >= 0)
            occupiedWaypoints.Remove(currentIndex);
    }
}

