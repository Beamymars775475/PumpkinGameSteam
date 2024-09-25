using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSystemMain : MonoBehaviour
{
    public Transform vineLeft;
    public Transform vineRight;

    public BoxCollider2D Ground;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.pumpkinKillCount >= 5 && GameManager.instance.pumpkinKillCount < 10)
        {
            vineLeft.transform.position = new Vector3(-6.5f, vineLeft.transform.position.y, vineLeft.transform.position.z);
            vineRight.transform.position = new Vector3(6.5f, vineRight.transform.position.y, vineRight.transform.position.z);
        }

        if (GameManager.instance.pumpkinKillCount >= 10 && GameManager.instance.pumpkinKillCount < 15)
        {
            vineLeft.transform.position = new Vector3(-9.25f, vineLeft.transform.position.y, vineLeft.transform.position.z);
            vineRight.transform.position = new Vector3(9.25f, vineRight.transform.position.y, vineRight.transform.position.z);
        }


        if (GameManager.instance.pumpkinKillCount >= 15)
        {
            vineLeft.transform.position = new Vector3(-12.25f, vineLeft.transform.position.y, vineLeft.transform.position.z);
            vineRight.transform.position = new Vector3(12.25f, vineRight.transform.position.y, vineRight.transform.position.z);
            Ground.isTrigger = true;
            GameManager.instance.isFloorClear = true;
        }
    }
}
