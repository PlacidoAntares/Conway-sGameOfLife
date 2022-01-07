using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLogic : MonoBehaviour
{
    public GameObject gridObj;
    private Grid grid_M;
    public bool ResetGrid = false;
    public float refreshRate;
    public Color CellAliveColorVal;
    public Color CellDeadColorVal;
    // Start is called before the first frame update
    void Start()
    {
        grid_M = gridObj.GetComponent<Grid>();
        refreshRate = grid_M.speed * Time.deltaTime;
        InvokeRepeating("GameIteration", 0,refreshRate); //higher values = slower refresh Rate
        PlaceCells();
    }

    // Update is called once per frame
    void Update()
    {
       ReplaceGrid();
    }

    public void ReplaceGrid()
    {
        if (ResetGrid == true)
        { 
            RemoveCells();
            PlaceCells();
            refreshRate = grid_M.speed * Time.deltaTime;
            ResetGrid = false;
            grid_M.simEnabled = true;
        }
    }

    public void TogglePause()
    {
        grid_M = gridObj.GetComponent<Grid>();
        grid_M.simEnabled = !grid_M.simEnabled;
    }
    public void ToggleReset()
    {
        ResetGrid = !ResetGrid;
    }
    void GameIteration()
    {
        Debug.Log("Iterating");
        if (grid_M.simEnabled)
        {
            CountNeighbors();
            PopControl();
        }
    }

    void RemoveCells()
    {
        grid_M = gridObj.GetComponent<Grid>();
        grid_M.gridSquares.AddRange(GameObject.FindGameObjectsWithTag("Square"));
        foreach (GameObject square in grid_M.gridSquares)
        {
            Destroy(square);
        }
        grid_M.gridSquares.Clear();
    }
    void PopControl()
    {
        grid_M = gridObj.GetComponent<Grid>();
        for (int y = 0; y < grid_M.screenHeight; ++y)
        {
            for (int x = 0; x < grid_M.screenWidth; ++x)
            {
                //-Rules
                //any live cell with 2 or 3 alive neighbors is active
                //any dead cell with 2 or 3 alive neighbors becomes active
                //all other live cells become inactive in the next generation
                //all other inactive cells stay dead
                if (grid_M.gridCells[x, y].isAlive)
                {
                    //Cell is active
                    if (grid_M.gridCells[x, y].numNeighbors != 2 && grid_M.gridCells[x, y].numNeighbors != 3)
                    {
                        grid_M.gridCells[x, y].SetAlive(false,CellAliveColorVal,CellDeadColorVal);
                    }
                }
                else
                {
                    //Cell is inactive
                    if (grid_M.gridCells[x, y].numNeighbors == 3)
                    {
                        grid_M.gridCells[x, y].SetAlive(true,CellAliveColorVal,CellDeadColorVal);
                    }
                }
            }
        }
    }
    void CountNeighbors()
    {
        grid_M = gridObj.GetComponent<Grid>();
        for (int y = 0; y < grid_M.screenHeight; ++y)
        {
            for (int x = 0; x < grid_M.screenWidth; x++)
            {
                int numNeighbors = 0;

                //North
                if (y + 1 < grid_M.screenHeight)
                {
                    if (grid_M.gridCells[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //East
                if (x + 1 < grid_M.screenWidth)
                {
                    if (grid_M.gridCells[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }

                }
                //South
                if (y - 1 >= 0)
                {
                    if (grid_M.gridCells[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //West
                if (x - 1 >= 0)
                {
                    if (grid_M.gridCells[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //North East
                if (x + 1 < grid_M.screenWidth && y + 1 < grid_M.screenHeight)
                {
                    if (grid_M.gridCells[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //North West
                if (x - 1 >= 0 && y + 1 < grid_M.screenHeight)
                {
                    if (grid_M.gridCells[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //SouthEast
                if (x + 1 < grid_M.screenWidth && y - 1 >= 0)
                {
                    if (grid_M.gridCells[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //SouthWest
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (grid_M.gridCells[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                grid_M.gridCells[x, y].numNeighbors = numNeighbors;

            }
        }
    }
    void PlaceCells()
    {
        Debug.Log("Placing New Cells");
        CellAliveColorVal = grid_M.CellAliveColorVal;
        CellDeadColorVal = grid_M.CellDeadColorVal;
        grid_M = gridObj.GetComponent<Grid>();
        for (int y = 0; y < grid_M.screenHeight; y++)
        {
            for (int x = 0; x < grid_M.screenWidth; x++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell; //instantiate the cell                
                grid_M.gridCells[x,y] = cell;
                grid_M.gridCells[x,y].SetAlive(RandomAliveCell(),grid_M.CellAliveColorVal,grid_M.CellDeadColorVal);
                
                //grid_M.gridCells[x, y].CellAliveColor = CellAliveColorVal;
                //grid_M.gridCells[x, y].CellDeadColor = CellDeadColorVal;
                
            }
        }
    }

    bool RandomAliveCell() //determines if a cell is alive or not randomly
    {
        grid_M = gridObj.GetComponent<Grid>();
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > grid_M.aliveChance)
        {
            return true;
        }
        return false;
    }
}
