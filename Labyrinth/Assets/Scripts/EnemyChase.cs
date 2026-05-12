using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseRadius = 30f;
    public float fieldOfView = 360f;
    public float patrolRadius = 15f;
    public float patrolWaitTime = 2f;

    private NavMeshAgent agent;
    private Vector3 patrolPoint;
    private bool patrolPointSet = false;
    private float patrolTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (PlayerInSight())
        {
            agent.SetDestination(player.position);
            patrolPointSet = false; 
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (!patrolPointSet)
        {
            patrolPoint = GetRandomPatrolPoint();
            patrolPointSet = true;
            agent.SetDestination(patrolPoint);
            patrolTimer = 0f;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolWaitTime)
            {
                patrolPointSet = false; 
            }
        }
    }

    private Vector3 GetRandomPatrolPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;

        if (NavMesh.SamplePosition(randomDirection, out navHit, patrolRadius, NavMesh.AllAreas))
        {
            return navHit.position;
        }
        else
        {
            return transform.position;
        }
    }

    private bool PlayerInSight()
    {
        if (player == null)
            return false;

        Vector3 origin = transform.position + Vector3.up * 1.5f;
        Vector3 directionToPlayer = (player.position - origin).normalized;
        float distanceToPlayer = Vector3.Distance(origin, player.position);

        if (distanceToPlayer > chaseRadius)
            return false;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (angle > fieldOfView / 2f)
            return false;

        if (Physics.Raycast(origin, directionToPlayer, out RaycastHit hit, chaseRadius))
        {
            if (hit.transform == player)
                return true;
        }

        return false;
    }
}

