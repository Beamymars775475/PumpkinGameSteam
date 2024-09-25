using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int scoreFloor;
    public int scoreRun;
    public int coinBank;
    

    public static GameManager instance {get; private set;}
    public int[] upgrade_level;

    public int[] temp_upgrade_level; // in a run

    public int pumpkinKillCount; 

    public int[,] levelsPumpkinsSave = new int[2,2]; // premier c'est ID et second c'est quantité 
    public bool isNeedToReloadUpgrade;

    public double upgrade_score_multi_info = 1;

    // public bool MouvementMouseOrKeyboards;

    public bool isFloorClear;

    public bool goNextFloor; // Next Level
    public int currentLevel;
    public bool isCycleEnd; // Cycle over

    public bool isGameOver;

    public int countPumpkinAlive; // Game Over

    public int comboMultiplyForEndFloor;

    public int currentCombo;


    public bool isUpgradeClaimed;
    public bool isRefreshNeeded;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        upgrade_level = new int[7];
        upgrade_level[0] = 0;
        upgrade_level[1] = 0;
        upgrade_level[2] = 0;
        upgrade_level[3] = 0;
        upgrade_level[4] = 0;
        upgrade_level[5] = 0;
        upgrade_level[6] = 0; // Faut check g fait nimp je crois

        temp_upgrade_level = new int[7];
        temp_upgrade_level[0] = 0;
        temp_upgrade_level[1] = 0;
        temp_upgrade_level[2] = 0;
        temp_upgrade_level[3] = 0;
        temp_upgrade_level[4] = 0;
        temp_upgrade_level[5] = 0;
        temp_upgrade_level[6] = 0;

        levelsPumpkinsSave[0, 0] = 2;
        levelsPumpkinsSave[0, 1] = 3;
        levelsPumpkinsSave[1, 0] = 0;
        levelsPumpkinsSave[1, 1] = 0;
        
        comboMultiplyForEndFloor = 1;


    }


    public void InitGame()
    {
        Debug.Log("Demarrage du jeu...");
    }

    public void UpdateTextNumber(TextMeshProUGUI someText, int theNewNumber) // Faut généraliser
    {
        someText.text = theNewNumber.ToString(); // Coroutine
    }


    // Si je vois un double de moi j'explose sinon je vie
    private void Awake() 
    {
        if(instance != null && instance != this)
        { 
            Destroy(gameObject); 
        }
        else
        {
            instance = this;
        }
    }
}


