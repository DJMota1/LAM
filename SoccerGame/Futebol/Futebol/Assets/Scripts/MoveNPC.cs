using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public List<Transform> waypoints;

    public Transform targetBall;
    public Rigidbody ball;

    public Transform goal;

    private float speed = 4f;
    private int current = 0;

    public static bool defenderMode = false;
    public static bool attackingMode = true;

    private float touchCooldown = 0.4f;
    private float touchTimer = 0f;

    void Update()
    {
        touchTimer -= Time.deltaTime;

        if(defenderMode)
        {
            Defend();
        }
        else if(attackingMode)
        {
            Attack();
        }
    }

    void Defend()
    {

        if(Vector3.Distance(
            waypoints[current].position,
            transform.position) < 1f)
        {
            current++;

            if(current >= waypoints.Count)
            {
                current = 0;
            }
        }

        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[current].position,
            step
        );

        Vector3 lookPos = targetBall.position;
        lookPos.y = transform.position.y;

        transform.LookAt(lookPos);
    }

    void Attack()
    {
        float step = speed * Time.deltaTime;

        float distanceToBall =
            Vector3.Distance(transform.position, targetBall.position);

        float distanceToGoal =
            Vector3.Distance(transform.position, goal.position);

        Vector3 goalDirection =
            (goal.position - ball.position).normalized;

        Vector3 lookPos = targetBall.position;
        lookPos.y = transform.position.y;

        transform.LookAt(lookPos);

        if(distanceToBall > 1.5f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetBall.position,
                step
            );
        }
        else
        {

            if(touchTimer <= 0f)
            {
                if(distanceToGoal > 15f)
                {
                    ball.AddForce(
                        goalDirection * 1f,
                        ForceMode.Impulse
                    );
                }
                else
                {
                    ball.AddForce(
                        goalDirection * 20f,
                        ForceMode.Impulse
                    );
                }

                touchTimer = touchCooldown;
            }
        }
    }
}