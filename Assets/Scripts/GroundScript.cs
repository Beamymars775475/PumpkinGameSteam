using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    int[] groundHealth;
    void Start()
    {
        groundHealth = new int[5];
        groundHealth[0] = 50;
        groundHealth[1] = 100;
        groundHealth[2] = 250;
        groundHealth[3] = 500;
        groundHealth[4] = 750;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
