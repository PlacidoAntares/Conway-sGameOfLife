using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputUI : MonoBehaviour
{
    //public bool UIEnabled;
    public GameObject gridManager;
    private Grid G_S;
    private GridLogic G_L;
    public GameObject gridLogic;
    public float RefreshRate;
    public int AliveChance;
    public Color RenderColorAlive;
    public Color RenderColorDead;
    public Image RenderSampleA;
    public Image RenderSampleB;
    public Slider redA;
    public Slider blueA;
    public Slider greenA;
    //
    public Slider redD;
    public Slider blueD;
    public Slider greenD;

    // Start is called before the first frame update
    void Start()
    {
       G_S = gridManager.GetComponent<Grid>();
        G_L = gridManager.GetComponent<GridLogic>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gridManager != null)
        {
           User_Input();           
        }
        RenderColorAlive = new Color(redA.value, blueA.value, greenA.value);
        G_S.CellAliveColorVal = RenderColorAlive;
        //G_L.CellAliveColorVal = RenderColorAlive;
        RenderSampleA.color = RenderColorAlive;
        RenderColorDead = new Color(redD.value, blueD.value, greenD.value);
        RenderSampleB.color = RenderColorDead;
        G_S.CellDeadColorVal = RenderColorDead;
        //G_L.CellAliveColorVal = RenderColorDead;
    }

    public void InputRefreshRate(string stringInput)
    {
       //Debug.Log(stringInput);
       if(float.TryParse(stringInput, out float value))
        {
            RefreshRate = value;
        }
       G_S.speed = RefreshRate;
       //Debug.Log("Refresh rate:" + RefreshRate);
    }
    public void InputAliveChance(string stringInput)
    {
        //Debug.Log(stringInput);
        if (int.TryParse(stringInput, out int value))
        {
            AliveChance = value;
        }
        G_S.aliveChance = AliveChance;
        //Debug.Log("Alive:" + AliveChance);
        
    }

    void User_Input()
    {
        if (Input.GetMouseButtonDown(0)) //toggle if a cell is alive or dead
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = Mathf.RoundToInt(mousePoint.x);
            int y = Mathf.RoundToInt(mousePoint.y);

            if (x >= 0 && y >= 0 && x < G_S.screenWidth && y < G_S.screenHeight)
            {
                //we are in bounds.
                Debug.Log("Click");
                G_S.gridCells[x, y].SetAlive(!G_S.gridCells[x, y].isAlive, G_S.CellAliveColorVal, G_S.CellDeadColorVal);
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            //toggle simulation
            G_S.simEnabled = !G_S.simEnabled;
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            //UIActive = !UIActive;
        }

    }
}
