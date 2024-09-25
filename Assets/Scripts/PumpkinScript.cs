using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour
{

    [SerializeField] Sprite[] pumpkinSprites;
    [SerializeField] float[] lenghtToDestination;


    bool isAbleMoving;
    int directionToMove;

    GameObject[] pumpSpawnGameobject;



    Transform pumpTransform;
    PumpkinSpawner pumpkinSpawner;


    public int pumpValue;
    public int pumpScore;

    public float comboMultiplicator = 1.00f;
    public float scoreMultiplicator = 1.00f; 

    public int startState;

    
    void Start()
    {
        pumpSpawnGameobject = GameObject.FindGameObjectsWithTag("PumpkinSpawner");
        pumpkinSpawner = pumpSpawnGameobject[0].GetComponent<PumpkinSpawner>();

        pumpTransform = gameObject.GetComponent<Transform>();

        isAbleMoving = false;

        StartCoroutine(cooldownBeforeFirstMove(0.1f));
    }


    void Update()
    {
        if(isAbleMoving == true)
        {
            StartCoroutine(pumpMovement(Random.Range(5, 20)/10));
        }

        if(isAbleMoving == false)
        {
            Vector3 trans = pumpTransform.position - new Vector3(pumpTransform.position.x, pumpTransform.position.y+(0.0025f*directionToMove), pumpTransform.position.z);

            if(startState == 0 || startState == 2)
            {
                trans = pumpTransform.position - new Vector3(pumpTransform.position.x, pumpTransform.position.y+0.0025f, pumpTransform.position.z);
                transform.Translate(trans, Space.World);

            }
            else if(startState == 1 || startState == 3)
            {
                trans = pumpTransform.position - new Vector3(pumpTransform.position.x, pumpTransform.position.y+(0.0025f*-1), pumpTransform.position.z);
                transform.Translate(trans, Space.World);
                
            }
            
            if((-4.3f<pumpTransform.position.y+trans.y && 4.3f>pumpTransform.position.y+trans.y)) // MinY et MaxY
            {
                transform.Translate(trans, Space.World);
                startState = 5; // Etat de non-effet
            }


        }

    }

    IEnumerator cooldownBeforeFirstMove(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isAbleMoving = true;          
    }


    IEnumerator pumpMovement(float cooldown)
    {
        isAbleMoving = false;
        yield return new WaitForSeconds(cooldown);
        directionToMove = Random.Range(-1, 2);
        isAbleMoving = true;
    }

    void LaunchAdditionalShinyGoldEffect()
    {
        Debug.Log("Launched");
    }



}
