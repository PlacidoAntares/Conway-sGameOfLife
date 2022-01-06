using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    
    public Color renderColorAlive;
    public Slider redA;
    public Slider blueA;
    public Slider greenA;
    public Color renderColorDead;
    public Slider redD;
    public Slider blueD;
    public Slider greenD;
    public Game_Manager manager;
    public Image renderSampleA;
    public Image renderSampleB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        renderColorAlive = new Color(redA.value, blueA.value, greenA.value);
        manager.CellColorAlive = renderColorAlive;
        renderSampleA.color = renderColorAlive;
        renderColorDead = new Color(redD.value, blueD.value, greenD.value);
        renderSampleB.color = renderColorDead;
        manager.CellColorDead = renderColorDead;
    }
}
