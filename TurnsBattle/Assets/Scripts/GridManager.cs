using System.Text;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject player;
    public GameObject enemy;
    public GameObject wall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int x = 0;x < 8; x++)
        {
            for (int z = 0;z < 8 ; z++)
            {
                Instantiate(tile,new Vector3(x,0,z),Quaternion.identity);
            }
        }

        Instantiate(player,new Vector3(0,1.5f,0),Quaternion.identity);
        Instantiate(player,new Vector3(2,1.5f,0),Quaternion.identity);
        Instantiate(player,new Vector3(0,1.5f,2),Quaternion.identity);

        Instantiate(enemy,new Vector3(6,1.5f,7),Quaternion.identity);
        Instantiate(enemy,new Vector3(5,1.5f,6),Quaternion.identity);
        Instantiate(enemy,new Vector3(4,1.5f,3),Quaternion.identity);
    }

    
}
