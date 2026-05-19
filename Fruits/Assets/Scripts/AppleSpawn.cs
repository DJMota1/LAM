using Unity.VisualScripting;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{

    public GameObject apple;

    public float timer = 2f;

    private int weight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            weight = Random.Range(0,2);
            Vector3 position = new Vector3(Random.Range(-7.0f, 7.0f), transform.position.y, transform.position.z);
            GameObject clone = Instantiate(apple, position, Quaternion.identity);
            if(weight == 0)
            {
                Apple.grams = 250;
            }
            else if(weight == 1)
            {
                Apple.grams = 250 * 1.5f;
                Transform cloneApple = clone.GetComponent<Transform>();
                cloneApple.localScale = cloneApple.localScale * 1.5f;
            }else
            {
                Apple.grams = 250 * 2f;
                Transform cloneApple = clone.GetComponent<Transform>();
                cloneApple.localScale = cloneApple.localScale * 2f;
            }
            timer = 2f;
        }
    }
}
