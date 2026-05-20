using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject [] bolas;
    public static int bolasMetidas = 0;
    public static bool bolaPreta = false;

        void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (bolasMetidas >= 5)
        {
            bolaPreta = true;
        }
    }
}
