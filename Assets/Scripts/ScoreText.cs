using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreText: MonoBehaviour
{
    public MoveWithMouse moveWithMouse;

    public TextMeshProUGUI textScoreUIFloor;
    public TextMeshProUGUI textScoreUIRun;

    public int oldScoreFloor;
    public int newScoreFloor;


    public int oldScoreRun;
    public int newScoreRun;


    public void Start()
    {
        oldScoreFloor = 0;
        oldScoreRun = GameManager.instance.scoreRun;
        GameManager.instance.UpdateTextNumber(textScoreUIFloor, GameManager.instance.scoreFloor);
        GameManager.instance.UpdateTextNumber(textScoreUIRun, oldScoreRun);

        if(SceneManager.GetActiveScene().name == "UpgradeScene")
        {
            StartCoroutine(addScoreForAnimationRun(0.5f)); // moveWithMouse.canIncrease = true; tout en attendant l'animation
        }
    }

    void Update()
    {
            newScoreFloor = GameManager.instance.scoreFloor;


            if(moveWithMouse.canIncrease == true && oldScoreFloor != newScoreFloor && SceneManager.GetActiveScene().name != "UpgradeScene") 
            {
                StartCoroutine(addScoreForAnimationFloor(0.025f));
            }

            if(newScoreRun == 0 && GameManager.instance.isFloorClear == true)
            {
                newScoreRun += GameManager.instance.scoreFloor;
            }

            if(moveWithMouse.canIncrease == true && oldScoreRun != newScoreRun*GameManager.instance.comboMultiplyForEndFloor && SceneManager.GetActiveScene().name == "UpgradeScene") 
            {
                StartCoroutine(addScoreForAnimationRun(0.00025f));
            }
            if(SceneManager.GetActiveScene().name == "UpgradeScene" && GameManager.instance.countPumpkinAlive != 0)
            {
                GameManager.instance.countPumpkinAlive = 0;
            }
            
    }
    
    IEnumerator addScoreForAnimationFloor(float cooldown)
    {
        moveWithMouse.canIncrease = false;

        oldScoreFloor++;
        GameManager.instance.UpdateTextNumber(textScoreUIFloor, oldScoreFloor);

        yield return new WaitForSeconds(cooldown);
        moveWithMouse.canIncrease = true;
    }

    IEnumerator addScoreForAnimationRun(float cooldown)
    {
        moveWithMouse.canIncrease = false;

        oldScoreRun += 1 * GameManager.instance.comboMultiplyForEndFloor;
        GameManager.instance.UpdateTextNumber(textScoreUIRun, oldScoreRun);

        yield return new WaitForSeconds(cooldown);
        moveWithMouse.canIncrease = true;
    }
}
