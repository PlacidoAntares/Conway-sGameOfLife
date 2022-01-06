using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //public variables

    //private variables
    private Game gameManage;
    private GameObject gameManager;
    public GameObject UIHandler;
    public bool UIActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("Manager");
        }
        if (gameManager != null)
        {
            gameManage = gameManager.GetComponent<Game>();
            User_Input();
            UIHandler.SetActive(UIActive);
        }
        
    }

    public void PauseSimulation()
    {
        if (gameManager != null)
        {
            gameManage.simEnabled = !gameManage.simEnabled;
        }      
    }
    void User_Input()
    {
        if (Input.GetMouseButtonDown(0)) //toggle if a cell is alive or dead
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = Mathf.RoundToInt(mousePoint.x);
            int y = Mathf.RoundToInt(mousePoint.y);

            if (x >= 0 && y >= 0 && x < gameManage.screenWidth && y < gameManage.screenHeight)
            {
                //we are in bounds.
                gameManage.grid[x, y].SetAlive(!gameManage.grid[x, y].isAlive);
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            //toggle simulation
            gameManage.simEnabled = !gameManage.simEnabled;
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            UIActive = !UIActive;
        }

    }
}
