using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject gameManager; //to be instantiated. Pass values livingCells,speed and color of square here
    public int livingCells; //must be greater than zero but less than or equal 100
    public float speed;
    public Color CellColorAlive;
    public Color CellColorDead;
    //
    private List<GameObject> gridSquares = new List<GameObject>();
    private GameObject square;
    private GameObject grid_Manager;
    public bool Reset;
    public bool SpawnNewGrid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResetGrid();        
    }

    public void ToggleReset()
    {
        Reset = !Reset;
    }
    void CreateNewGrid()
    {
            grid_Manager = Instantiate(gameManager, new Vector3(0, 0, 0), Quaternion.identity);
            grid_Manager.GetComponent<Game>().CellAliveColorVal = CellColorAlive;
            grid_Manager.GetComponent<Game>().CellDeadColorVal = CellColorDead;
            grid_Manager.GetComponent<Game>().aliveChance = livingCells;
            grid_Manager.GetComponent<Game>().speed = speed;
    }
    void ResetGrid()
    {
        if (Reset == true)
        {
            grid_Manager = GameObject.FindGameObjectWithTag("Manager");
            gridSquares.AddRange(GameObject.FindGameObjectsWithTag("Square"));
            Destroy(grid_Manager);
            foreach (GameObject square in gridSquares)
            {
                Destroy(square);
            }
            gridSquares.Clear();
            CreateNewGrid();
            Reset = false;
        }
    }
}
