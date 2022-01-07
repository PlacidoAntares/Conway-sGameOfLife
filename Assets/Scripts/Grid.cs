using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int aliveChance;
    public float speed;
    public bool simEnabled;
    public int screenWidth;
    public int screenHeight;
    public Color CellAliveColorVal;
    public Color CellDeadColorVal;
    public List<GameObject> gridSquares = new List<GameObject>();
    /// <summary>
    /// private variables
    /// </summary>
    //private float refreshRate;
    private static int Screen_Width = 64; //1024 pixels
    private static int Screen_Height = 48; //768 pixels
    public Cell[,] gridCells = new Cell[Screen_Width, Screen_Height];
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen_Width;
        screenHeight = Screen_Height;
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
