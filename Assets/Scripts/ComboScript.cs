using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ComboScript : MonoBehaviour
{
    // Start is called before the first frame update



    public int[] comboReach;
    
    public int comboLevel;


    public bool canDicrease;

    public ProgressBarScript progressBarScript;
    public MoveWithMouse moveWithMouse;

    public TextMeshProUGUI textCombo;
    void Start()
    {
        canDicrease = true; 

        comboReach= new int[6];
        comboReach[0] = 100; 
        comboReach[1] = 250;
        comboReach[2] = 500; 
        comboReach[3] = 1000; 
        comboReach[4] = 2500; 
        comboReach[5] = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        if(progressBarScript.current > 0 && canDicrease && SceneManager.GetActiveScene().name != "UpgradeScene")
        {
            progressBarScript.current--;
            StartCoroutine(comboDicreaseCooldown(0.035f));
        }

        if(progressBarScript.current <= comboReach[0])
        {
            progressBarScript.minimum = 0;
            progressBarScript.maximum = comboReach[0];
            comboLevel = 1;
        }
        else if (progressBarScript.current <= comboReach[1])
        {
            progressBarScript.minimum = comboReach[0];
            progressBarScript.maximum = comboReach[1];
            comboLevel = 2;
        }
        else if (progressBarScript.current <= comboReach[2])
        {
            progressBarScript.minimum = comboReach[1];
            progressBarScript.maximum = comboReach[2];
            comboLevel = 3;
        }
        else if (progressBarScript.current <= comboReach[3])
        {
            progressBarScript.minimum = comboReach[2];
            progressBarScript.maximum = comboReach[3];
            comboLevel = 4;
        }
        else if (progressBarScript.current <= comboReach[4])
        {
            progressBarScript.minimum = comboReach[3];
            progressBarScript.maximum = comboReach[4];
            comboLevel = 5;
        }
        else if (progressBarScript.current <= comboReach[5])
        {
            progressBarScript.minimum = comboReach[4];
            progressBarScript.maximum = comboReach[5];
            comboLevel = 6;
        }

        textCombo.text = "x" + comboLevel;

        if(moveWithMouse.NeedToEditCoin == true)
        {
            progressBarScript.current += moveWithMouse.currentPumpkinValue;
            moveWithMouse.currentPumpkinValue = 0;
            moveWithMouse.NeedToEditCoin = false;
        }

        if(GameManager.instance.isFloorClear == true & SceneManager.GetActiveScene().name != "UpgradeScene")
        {
            GameManager.instance.comboMultiplyForEndFloor = comboLevel;
        }

        if(SceneManager.GetActiveScene().name == "UpgradeScene")
        {
            progressBarScript.current = comboReach[GameManager.instance.comboMultiplyForEndFloor-1];
        }

    }

    IEnumerator comboDicreaseCooldown(float cooldown)
    {
        canDicrease = false;
        yield return new WaitForSeconds(cooldown);
        canDicrease = true;
    }


}
