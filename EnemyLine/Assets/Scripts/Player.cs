using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool key = false;
    private bool weapon = false;

    public Transform firepoint;
    public GameObject bullet;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.name == "Door")
                {
                    Animator anim = hit.collider.gameObject.GetComponentInParent<Animator>();
                    anim.Play("Open");
                }
                if (hit.collider.gameObject.name == "ClosedDoor" && key)
                {
                    Animator anim = hit.collider.gameObject.GetComponentInParent<Animator>();
                    anim.Play("Open");
                }
                if (hit.collider.gameObject.CompareTag("Walk"))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

        if (weapon && Input.GetMouseButtonDown(0))
        {
          Instantiate(bullet, firepoint.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
            key = true;
        }
        if (other.gameObject.name == "gun")
        {
            Destroy(other.gameObject);
            weapon = true;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
