using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive = false; //tracks if the cell is alive or not
    public int numNeighbors = 0; //tracks number of neighbors beside the cell
    public Color CellAliveColor; //stores RGB color values
    public Color CellDeadColor;  //Stores RGB color values

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        if (alive) //if alive is true  enable sprite renderer
        {
           //GetComponent<SpriteRenderer>().enabled = true;
           GetComponent<SpriteRenderer>().color = CellAliveColor;
        }
        else
        {
            //GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = CellDeadColor;
        }
    }
}
