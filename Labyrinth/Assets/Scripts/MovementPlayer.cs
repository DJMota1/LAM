using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool hasKey = false;
    public AudioClip keyPickupSound;
    private AudioSource audioSource;
    private string centerMessage = "";
    private float centerMessageEndTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            audioSource.PlayOneShot(keyPickupSound);
            Destroy(other.gameObject);
            hasKey = true;
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
        else if (other.CompareTag("Door"))
        {
            if (hasKey)
                SceneManager.LoadScene("Win");
            else
                ShowCenterMessage("You need a key to escape!", 3f);
        }
    }

    void ShowCenterMessage(string message, float duration)
    {
        centerMessage = message;
        centerMessageEndTime = Time.time + duration;
    }

    void OnGUI()
    {
        if (hasKey)
        {
            GUI.Label(new Rect(10, 10, 300, 30), "You have the key");
        }

        if (!string.IsNullOrEmpty(centerMessage) && Time.time < centerMessageEndTime)
        {
            var size = GUI.skin.label.CalcSize(new GUIContent(centerMessage));
            float x = (Screen.width - size.x) / 2;
            float y = (Screen.height - size.y) / 2;
            GUI.Label(new Rect(x, y, size.x, size.y), centerMessage);
        }
        else
        {
            centerMessage = "";
        }
    }
}
