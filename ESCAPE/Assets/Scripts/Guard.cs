using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public float detectionRange = 3f;
    private Transform player;

    private UnityEngine.AI.NavMeshAgent agent;

    private enum State { Patrol, Chase }
    private State currentState = State.Patrol;

    public GameObject key;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        agent.autoBraking = false;
        GoToNextWaypoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            currentState = State.Chase;
        }
        else if (currentState == State.Chase && distanceToPlayer > detectionRange)
        {
            currentState = State.Patrol;
            GoToNextWaypoint();
        }

        if (currentState == State.Patrol)
        {
            Patrol();
        }
        else if (currentState == State.Chase)
        {
            ChasePlayer();
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;
        bool validDestination = agent.SetDestination(waypoints[currentWaypointIndex].position);
        Debug.Log("SetDestination válido? " + validDestination);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(key,transform.position,Quaternion.identity);
        }
    }
}
