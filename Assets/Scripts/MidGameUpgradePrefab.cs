using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGameUpgradePrefab : MonoBehaviour
{
    public int nb_tag_up;
    public Transform upgrade_transform;

    public int idUpgrade;



    void Start()
    {
        if(nb_tag_up == 0)
        {
            upgrade_transform.position = new Vector3(-5.25f, 1.25f, gameObject.transform.position.z);

            return;
        }
        if(nb_tag_up == 1)
        {
            upgrade_transform.position = new Vector3(-5.25f, -1.25f, gameObject.transform.position.z);


            return;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isUpgradeClaimed)
        {
            Destroy(gameObject);
        }
    }
}
