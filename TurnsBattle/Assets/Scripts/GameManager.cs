using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerTurn = true;

    public Unidade selectedUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Unidade unit = hit.collider.GetComponent<Unidade>();

                    if (unit != null && unit.isPlayer)
                    {
                        selectedUnit = unit;
                        return;
                    }

                    if (hit.collider.CompareTag("Tile"))
                    {
                        Debug.Log("Cliquei num tile");

                        if (selectedUnit != null)
                        {
                            Debug.Log("Unidade selecionada: " + selectedUnit.name);

                            float dist =
                                Mathf.Abs(hit.collider.transform.position.x - selectedUnit.transform.position.x)
                                +
                                Mathf.Abs(hit.collider.transform.position.z - selectedUnit.transform.position.z);

                            Debug.Log("Distancia: " + dist);

                            if (dist <= 2)
                            {
                                Debug.Log("Pode mover");

                                float step = 100f * Time.deltaTime;

                                Debug.Log("Step: " + step);

                                Debug.Log("Posição antes: " + selectedUnit.transform.position);

                                selectedUnit.transform.position =
                                    Vector3.MoveTowards(
                                        selectedUnit.transform.position,
                                        hit.collider.transform.position,
                                        step
                                    );

                                Debug.Log("Posição depois: " + selectedUnit.transform.position);

                                playerTurn = false;
                                selectedUnit.hasMoved = true;

                                EnemyTurn();
                            }
                            else
                            {
                                Debug.Log("Muito longe");
                            }
                        }
                        else
                        {
                            Debug.Log("Nenhuma unidade selecionada");
                        }
                    }
                }
            }
        }

        [System.Obsolete]
        void EnemyTurn()
        {
            EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
            foreach (EnemyAI enemy in enemies)
            {
                enemy.DoTurn();
            }
            playerTurn = true;
        }
    }
}
