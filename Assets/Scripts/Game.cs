using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int aliveChance;
    public float speed;
    public bool simEnabled = true;
    public int screenWidth;
    public int screenHeight;
    public Color CellAliveColorVal;
    public Color CellDeadColorVal;
    /// <summary>
    /// private variables
    /// </summary>
    private float refreshRate;
    public static int Screen_Width = 64; //1024 pixels
    public static int Screen_Height = 48; //768 pixels
    public Cell[,] grid = new Cell[Screen_Width, Screen_Height];
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen_Height;
        screenWidth = Screen_Width;

    refreshRate = speed * 0.01f;
     PlaceCells();
     InvokeRepeating("GameIteration",0,refreshRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameIteration()
    {
       if (simEnabled)
        {
            CountNeighbors();
            PopControl();
        }
    
    }

    void PlaceCells()
    {
        for (int y = 0; y < Screen_Height; y++)
        {
            for (int x = 0; x < Screen_Width; x++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell; //instantiate the cell
                grid[x, y] = cell;
                grid[x, y].CellAliveColor = CellAliveColorVal;
                grid[x, y].CellDeadColor = CellDeadColorVal;
                grid[x, y].SetAlive(RandomAliveCell());
            }
        }
        
    }
    bool RandomAliveCell() //determines if a cell is alive or not randomly
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > aliveChance)
        {
            return true;
        }
        return false;
    }

    void PopControl()
    {
        for (int y = 0; y < Screen_Height; ++y)
        {
            for (int x = 0; x < Screen_Width; ++x)
            {
                //-Rules
                //any live cell with 2 or 3 alive neighbors is active
                //any dead cell with 2 or 3 alive neighbors becomes active
                //all other live cells become inactive in the next generation
                //all other inactive cells stay dead
                if (grid[x, y].isAlive)
                {
                    //Cell is active
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        grid[x,y].SetAlive(false);
                    }
                }
                else
                {
                    //Cell is inactive
                    if (grid[x, y].numNeighbors == 3)
                    {
                        grid[x, y].SetAlive(true);
                    }
                }
            }
        }
    }
    void CountNeighbors()
    {
        for(int y = 0; y < Screen_Height; ++y)
        {
            for (int x = 0; x < Screen_Width; x++)
            {
                int numNeighbors = 0;

                //North
                if(y+1 < Screen_Height)
                {
                    if (grid[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //East
                if (x + 1 < Screen_Width)
                {
                    if (grid[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }

                }
                //South
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //West
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //North East
                if (x + 1 < Screen_Width && y + 1 < Screen_Height)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //North West
                if(x-1 >= 0 && y+1 < Screen_Height)
                {
                    if(grid[x-1,y+1].isAlive)
                    {
                        numNeighbors++;
                    }    
                }
                //SouthEast
                if (x + 1 < Screen_Width && y - 1 >= 0)
                {
                    if (grid[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                //SouthWest
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }
                grid[x, y].numNeighbors = numNeighbors;

            }
        }
    }
}
