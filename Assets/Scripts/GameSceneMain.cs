using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMain : MonoBehaviour
{
    public int comboRage;

    public int[] comboLevel;
    public MoveWithMouse moveWithMouse;

    public int[] HPwalls;

    void Start()
    {
        comboLevel = new int[8];
        comboLevel[0] = 10;
        comboLevel[1] = 25;
        comboLevel[2] = 100;
        comboLevel[3] = 500;
        comboLevel[4] = 1000;
        comboLevel[5] = 2000;
        comboLevel[6] = 5000;
        comboLevel[7] = 10000;
    }


    void Update()
    {
        if(moveWithMouse.touchAPumpkin)
        {
            comboRage += 1;
            moveWithMouse.touchAPumpkin = false;
        }
    }


}
