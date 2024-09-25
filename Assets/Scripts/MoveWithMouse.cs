using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class MoveWithMouse : MonoBehaviour
{
    [Header("MovementMouseCore")]
    //the object to move
    public Transform moveThis;
    //the layers the ray can hit
    public LayerMask hitLayers;
    public SpriteRenderer spriteRenderPlayer;

    public float timeOffSet;
    private Vector3 velocity;

    float rayLength = 0.5f;
        
	Vector3 dir;
	Ray ray;
    RaycastHit hit_ray;
    public LayerMask hitLayers2;


    
    [Header("Dash")]
    public Rigidbody2D rb;

    bool NeedToGoToMouse = true;
    bool BeShooted = true;

    public bool NeedToEditCoin;
    public float cooldownUntilDash;

    public int numberOfEnnemiesKilled;

    [Header("AnimationSprite")]
    public Sprite AngrySprite;
    public Sprite FineSprite;
    public Sprite AttackSprite;

    public bool touchAPumpkin;

    public bool hasAlreadyScretchFeedbacks;

    public float coordinatesXOffSet;
    

    [Header("Feedbacks")]

    public MMF_Player SwitchingSidesScretchFeedbacks;
    public MMF_Player SwitchingMoodsScretchFeedbacks;

    public int currentPumpkinValue;

    public bool canIncrease;


    private void Start()
    {
        Cursor.visible = true;
        touchAPumpkin = false;
    }
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPointmouse = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hitMouse;

        if (Physics.Raycast(castPointmouse, out hitMouse, Mathf.Infinity, hitLayers))
        {
            Vector3 targetPos = hitMouse.point;

            dir = transform.TransformDirection(new Vector3(moveThis.transform.position.x - targetPos.x, 0, 0));


            ray = new Ray(moveThis.transform.position, dir * rayLength);

            Debug.DrawRay(moveThis.transform.position, ray.direction, Color.green);

            if (!Physics.Raycast(ray, out hit_ray, Mathf.Infinity, hitLayers2) && NeedToGoToMouse)
            {
                Vector3 ForceToGoToMouse = Vector3.SmoothDamp(moveThis.position, new Vector3((targetPos.x/3)+coordinatesXOffSet, targetPos.y, 0), ref velocity, timeOffSet); 

                moveThis.transform.position = ForceToGoToMouse; 
            }


            if(targetPos.x > 0.25f)
            {
                spriteRenderPlayer.flipX = false;
                hasAlreadyScretchFeedbacks = false;
            }
            else if(targetPos.x < -0.25f)
            {
                spriteRenderPlayer.flipX = true;
                hasAlreadyScretchFeedbacks = false;
            } 
            else if (!hasAlreadyScretchFeedbacks && ((targetPos.x > 0f && spriteRenderPlayer.flipX == true) || (targetPos.x < 0f && spriteRenderPlayer.flipX == false))) 
            {
                SwitchingSidesScretchFeedbacks.PlayFeedbacks();
                hasAlreadyScretchFeedbacks = true;
            }

            if(targetPos.x > 4f || targetPos.x < -4f && NeedToGoToMouse)
            {
               spriteRenderPlayer.sprite = AngrySprite;
               SwitchingMoodsScretchFeedbacks.PlayFeedbacks();
            }
            else if(targetPos.x < 3.9f || targetPos.x > -3.9f && NeedToGoToMouse)
            {
                spriteRenderPlayer.sprite = FineSprite;
    
            } 
            if(!NeedToGoToMouse)  
            {
                spriteRenderPlayer.sprite = AttackSprite;
            }
    
            if(Input.GetKey(KeyCode.LeftArrow) && BeShooted)
            {
                BeShooted = false;
                NeedToGoToMouse = false;
                rb.AddForce(new Vector2(-30f, 0f), ForceMode2D.Impulse);
                Invoke("GoBackToMouse", cooldownUntilDash);
            }
            if(Input.GetKey(KeyCode.RightArrow) && BeShooted)
            {
                BeShooted = false;
                NeedToGoToMouse = false;
                rb.AddForce(new Vector2(30f, 0f), ForceMode2D.Impulse);
                Invoke("GoBackToMouse", cooldownUntilDash);
            }
            if(Input.GetKey(KeyCode.DownArrow) && BeShooted)
            {
                BeShooted = false;
                NeedToGoToMouse = false;
                rb.AddForce(new Vector2(0f, -35f), ForceMode2D.Impulse);
                Invoke("GoBackToMouse", cooldownUntilDash);
            }


        }           

        if(numberOfEnnemiesKilled>0)
        {
            numberOfEnnemiesKilled--;       
        }
                    

    
    }

    public void OnCollisionEnter2D(Collision2D _col) 
    {
        if(_col.gameObject.tag == "Wall")
        {
            NeedToGoToMouse = true;
        }
        if(_col.gameObject.tag == "Pumpkin")
        {
            NeedToGoToMouse = true;
            PumpkinScript pumpPumpkinScript = _col.gameObject.GetComponent<PumpkinScript>();
            GameManager.instance.scoreFloor += (int)(pumpPumpkinScript.pumpValue * pumpPumpkinScript.scoreMultiplicator);
            currentPumpkinValue += (int)(pumpPumpkinScript.pumpScore * pumpPumpkinScript.comboMultiplicator);
            canIncrease = true; // Score citrouille
            touchAPumpkin = true;
            NeedToEditCoin = true;
            GameManager.instance.pumpkinKillCount++;
            Destroy(_col.gameObject);
        }
        if(_col.gameObject.tag == "Windleft")
        {
            coordinatesXOffSet = 3;
        }

        if(_col.gameObject.tag == "BlackWall")
        {
            GameManager.instance.goNextFloor = true;
        }


        if(_col.gameObject.tag == "Upgrade") // Upgrade entre les niveaux
        {
            NeedToGoToMouse = true;
            MidGameUpgradePrefab upgradeMidGameScript = _col.gameObject.GetComponent<MidGameUpgradePrefab>();
            GameManager.instance.temp_upgrade_level[upgradeMidGameScript.idUpgrade]++; 
            GameManager.instance.isUpgradeClaimed = true;
            Destroy(_col.gameObject);
        }

        if(_col.gameObject.tag == "RefreshUpgrades") // Refresh pour les upgrades entre les niveaux
        {
            NeedToGoToMouse = true;
            GameManager.instance.isRefreshNeeded  = true;
            Destroy(_col.gameObject);
        }

    }

    public void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Windleft" && coordinatesXOffSet <= 2.0f)
        {
            coordinatesXOffSet += 0.1f;
        }
        if(_col.gameObject.tag == "Windright"  && coordinatesXOffSet >= -2.0f)
        {
            coordinatesXOffSet -= 0.1f;
        }
    }

    public void OnTriggerExit2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Windleft")
        {
            coordinatesXOffSet = 0;
        }
        if(_col.gameObject.tag == "Windright")
        {
            coordinatesXOffSet = 0f;
        }

    }


    public void GoBackToMouse()
    {
        BeShooted = true;
    }

}