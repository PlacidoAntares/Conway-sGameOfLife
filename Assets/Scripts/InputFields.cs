using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputFields : MonoBehaviour
{
    public GameObject UI_Manager;
    private Game_Manager UIManager;

    public float RefreshRate;
    public int AliveChance;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = UI_Manager.GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputRefreshRate(string stringInput)
    {
       //Debug.Log(stringInput);
       if(float.TryParse(stringInput, out float value))
        {
            RefreshRate = value;
        }
       UIManager.speed = RefreshRate;
       //Debug.Log("Refresh rate:" + RefreshRate);
    }
    public void InputAliveChance(string stringInput)
    {
        //Debug.Log(stringInput);
        if (int.TryParse(stringInput, out int value))
        {
            AliveChance = value;
        }
        UIManager.livingCells = AliveChance;
        //Debug.Log("Alive:" + AliveChance);
        
    }
}
