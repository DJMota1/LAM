using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    private int currentFloor = 3;
    private bool movingUp = true;

    void Update()
    {
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= 2f)
            {
                isWaiting = false;
                waitTimer = 0f;
            }
            else
            {
                return;
            }
        }

        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "1" || other.gameObject.name == "2" || other.gameObject.name == "3")
        {
            isWaiting = true;
            currentFloor = int.Parse(other.gameObject.name);

            if (currentFloor == 1)
            {
                movingUp = true;
            }
            else if (currentFloor == 3)
            {
                movingUp = false;
            }
        }
    }
    

}
