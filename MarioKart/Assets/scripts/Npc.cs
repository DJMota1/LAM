using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{

    public Transform[] waypoints;
    public int currentWaypoint = 0;

    public float speed = 8f;
    public float waypointReachDistance = 2f;
    public float rayDistance = 3.5f;

    public float overtakeOffset = 2.5f;

    public int totalLaps = 3;
    public Transform finishLine;
    public float finishLineTriggerDistance = 3f;
    public int currentLap = 0;
    bool waitingForFinishLine = false;
    public bool raceFinished = false;

    private NavMeshAgent agent;
    private Vector3 overtakeDir = Vector3.zero;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.angularSpeed = 200f;
        agent.acceleration = 8f;
        GoToNextWaypoint();
    }

    void Update()
    {
        if (raceFinished) return;

        CheckRays();
        CheckFinishLine();

        if (!agent.pathPending && agent.remainingDistance < waypointReachDistance)
        {
            if (currentWaypoint == waypoints.Length - 1)
            {
                waitingForFinishLine = true;
                agent.SetDestination(finishLine.position);
            }
            else
            {
                currentWaypoint++;
                GoToNextWaypoint();
            }
        }
    }

    void CheckFinishLine()
    {
        if (!waitingForFinishLine) return;

        float distToFinish = Vector3.Distance(transform.position, finishLine.position);

        if (distToFinish < finishLineTriggerDistance)
        {
            currentLap++;
            Debug.Log(gameObject.name + " completou volta " + currentLap);
            waitingForFinishLine = false;

            if (currentLap >= totalLaps)
            {
                raceFinished = true;
                agent.ResetPath();
                Debug.Log(gameObject.name + " terminou a corrida!");
                return;
            }

            currentWaypoint = 0;
            GoToNextWaypoint();
        }
    }

    void CheckRays()
    {
        Vector3 origin = transform.position + Vector3.up * 0.3f;
        Vector3 leftOrigin = origin - transform.right * 0.5f;
        Vector3 rightOrigin = origin + transform.right * 0.5f;

        bool frontHit = Physics.Raycast(origin, transform.forward, rayDistance);
        bool leftHit = Physics.Raycast(leftOrigin, transform.forward, rayDistance);
        bool rightHit = Physics.Raycast(rightOrigin, transform.forward, rayDistance);

        Debug.DrawRay(origin, transform.forward * rayDistance, Color.red);
        Debug.DrawRay(leftOrigin, transform.forward * rayDistance, Color.blue);
        Debug.DrawRay(rightOrigin, transform.forward * rayDistance, Color.green);

        if (frontHit)
            agent.speed = Mathf.Lerp(agent.speed, speed * 0.4f, Time.deltaTime * 3f);
        else
            agent.speed = Mathf.Lerp(agent.speed, speed + 2f, Time.deltaTime * 3f);

        if (rightHit && !leftHit)
        {
            overtakeDir = -transform.right;
            GoToNextWaypoint();
        }
        else if (!rightHit && leftHit)
        {
            overtakeDir = transform.right;
            GoToNextWaypoint();
        }
        else if (!frontHit && !leftHit && !rightHit)
        {
            overtakeDir = Vector3.zero;
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        Vector3 destination = waypoints[currentWaypoint].position + overtakeDir * overtakeOffset;
        agent.SetDestination(destination);
    }
}
