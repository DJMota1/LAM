using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Unidade myUnit;

    void Start()
    {
        myUnit = GetComponent<Unidade>();
    }

    [System.Obsolete]
    public void DoTurn()
    {
        Unidade [] allUnits = FindObjectsOfType<Unidade>();
        Unidade target = null;

        float minDist = 999f;

        foreach(Unidade u in allUnits)
        {
            if (u.isPlayer)
            {
                float d = Vector3.Distance(transform.position,u.transform.position);

                if(d < minDist)
                {
                    minDist = d;
                    target = u;
                }
            }
        }
        if(minDist <= 2.5f)
        {
            transform.LookAt(target.transform);
            Destroy(target.gameObject); // tenho que depois meter balas

            return;
        }

        Vector3 newPos = transform.position;

        if(target.transform.position.x > transform.position.x)
        {
            newPos.x += 2;
        }else if(target.transform.position.x < transform.position.x)
        {
            newPos.x -= 2;
        }

        if(target.transform.position.z > transform.position.z)
        {
            newPos.x += 2;
        }else if(target.transform.position.z < transform.position.z)
        {
            newPos.z -= 2;
        }

        transform.position = new Vector3(Mathf.Clamp(newPos.x,0,9),0.5f,Mathf.Clamp(newPos.z,0,9));
    }
}