using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using System.Data.Common;



public class PumpkinSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pumpPrefab;
    private float WallToSpawnCoordinatesX;
    private float WallToSpawnCoordinatesY;
    bool canBeSpawn;
    bool haveTouchGround;

    public float CoordinatesLeftWallPumpkin;
    public float CoordinatesRightWallPumpkin;

    public float CoordinatesUpWallPumpkin;
    public float CoordinatesDownWallPumpkin;

    int variationPumpkin;

    public Material materialRainbow;
    public Material materialGold;

    public int[] levelsPumpkins; // level actuel


    
    void Start()
    {
        levelsPumpkins = new int[GameManager.instance.levelsPumpkinsSave.GetLength(GameManager.instance.currentLevel)]; 
        GameManager.instance.isCycleEnd = true;
        canBeSpawn = true;

    }
    void Update()
    {
        //if(canBeSpawn) //Mort du joueur
        //{
        //    pumpSpawnFunc(0.75f);
        //}

        while(GameManager.instance.isCycleEnd == false && canBeSpawn == true)
        {
            pumpSpawnFunc(0.75f);
        }
        if(GameManager.instance.isCycleEnd == true)
        {
            GameManager.instance.isCycleEnd = false;


            
            for (int i = 0; i < GameManager.instance.levelsPumpkinsSave.GetLength(GameManager.instance.currentLevel); i++)
            {
                levelsPumpkins[i] = GameManager.instance.levelsPumpkinsSave[GameManager.instance.currentLevel,i];
            }
        }

        if(GameManager.instance.countPumpkinAlive - GameManager.instance.pumpkinKillCount >= 10)
        {
            if(GameManager.instance.isFloorClear)
            {
                Debug.Log("Faut faire un truc");
                // GameManager.instance.goNextFloor = true;
                // Force to go to next floor 
            }
            else
            {
                GameManager.instance.isGameOver = true;
            }

        }
    }

    IEnumerator pumpSpawn(float cooldown)
    {
        canBeSpawn = false;
        var WallPosition = Random.Range(0, 4);
        int prefabRotation;
        //Les cos du murs
        
        if(WallPosition == 0)
        {
            WallToSpawnCoordinatesX = CoordinatesLeftWallPumpkin;
            WallToSpawnCoordinatesY = CoordinatesUpWallPumpkin;
            prefabRotation = -90;

        }
        else if(WallPosition == 1)
        {
            WallToSpawnCoordinatesX = CoordinatesLeftWallPumpkin;
            WallToSpawnCoordinatesY = CoordinatesDownWallPumpkin;
            prefabRotation = -90;
        }
        else if(WallPosition == 2)
        {
            WallToSpawnCoordinatesX = CoordinatesRightWallPumpkin;
            WallToSpawnCoordinatesY = CoordinatesUpWallPumpkin;
            prefabRotation = 90;
        }
        else
        {
            WallToSpawnCoordinatesX = CoordinatesRightWallPumpkin;
            WallToSpawnCoordinatesY = CoordinatesDownWallPumpkin;
            prefabRotation = 90;
        }



        int randID = Random.Range(0, levelsPumpkins.GetLength(GameManager.instance.currentLevel)); // [0]
        int countEmptyPumpkinsStorage = 0;

        for (int i = 0; i < levelsPumpkins.GetLength(GameManager.instance.currentLevel); i++)
        {

            if(levelsPumpkins[i] <= 0)
            {
                countEmptyPumpkinsStorage++;
            }
        }

        if(countEmptyPumpkinsStorage == levelsPumpkins.GetLength(GameManager.instance.currentLevel)) // [GameManager.instance.currentLevel]
        {
            GameManager.instance.isCycleEnd = true;
        }
        else
        {
            countEmptyPumpkinsStorage = 0;
        }

        while (levelsPumpkins[randID] <= 0 && GameManager.instance.isCycleEnd == false) 
        {
            randID = Random.Range(0, levelsPumpkins.GetLength(0)); // [0]
        }

        var position = new Vector3(WallToSpawnCoordinatesX, WallToSpawnCoordinatesY);

        GameObject prefab = Instantiate(pumpPrefab[randID], position, Quaternion.identity);
        levelsPumpkins[randID] -= 1;

        prefab.transform.rotation = Quaternion.Euler(new Vector3(0,0,prefabRotation));

        variationPumpkin = Random.Range(0, 100); // Systeme de variation citrouilles (gold, rainbow) 

        PumpkinScript prefabScript = prefab.GetComponent<PumpkinScript>();
        prefabScript.startState = WallPosition;
        

        if(variationPumpkin < 25)
        {
            prefab.GetComponent<Renderer>().material = materialRainbow;
            prefabScript.comboMultiplicator = 1.25f;
        }
        else if (variationPumpkin < 50)
        {
            prefab.GetComponent<Renderer>().material = materialGold;
            prefabScript.scoreMultiplicator = 1.25f;

            
            Animation prefabAnim = prefab.GetComponent<Animation>();
            prefabAnim.Play();

        }

        if(WallPosition == 2 && prefab.transform.Find("Pumpkin_HeliceWind") != null || WallPosition == 3 && prefab.transform.Find("Pumpkin_HeliceWind") != null)
        {
            Transform child = prefab.transform.Find("Pumpkin_HeliceWind");
            child.tag = "Windright";
        }
        
        yield return new WaitForSeconds(cooldown);
        canBeSpawn = true;

    }
    

    public void pumpSpawnFunc(float cooldown)
    {
        StartCoroutine(pumpSpawn(cooldown));
        GameManager.instance.countPumpkinAlive++;
    }
}
