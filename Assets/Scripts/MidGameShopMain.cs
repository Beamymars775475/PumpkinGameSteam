using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MidGameShopMain : MonoBehaviour
{
    public MidGameUpgradePrefab upgradePrefab;

    MidGameUpgradePrefab upgradeInstance;

    public bool isClearingUpgrades;

    void Start()
    {
        NewUpgrade("Up 1");
        NewUpgrade("Up 2");
    }
    void Update()
    {
        if(GameManager.instance.isRefreshNeeded && isClearingUpgrades == false)
        {
            StartCoroutine(UpdateClear());
        }


    }

    public void NewUpgrade(string nameUpgrade)
    {       
        upgradeInstance = GameObject.Instantiate<MidGameUpgradePrefab>(upgradePrefab);    
        upgradeInstance.name = nameUpgrade;
        upgradeInstance.upgrade_transform = upgradeInstance.GetComponent(typeof(Transform)) as Transform;
        GameObject[] gameobject_tag_upgrade = GameObject.FindGameObjectsWithTag("Upgrade");
        upgradeInstance.nb_tag_up = gameobject_tag_upgrade.Length-1;

        upgradeInstance.idUpgrade = Random.Range(0, 7);

    }

    IEnumerator UpdateClear()
    {
        GameManager.instance.isUpgradeClaimed = true;
        isClearingUpgrades = true;
        


        yield return new WaitForSeconds(0.25f);
        NewUpgrade("Up 1");
        NewUpgrade("Up 2");

        GameManager.instance.isUpgradeClaimed = false;
        isClearingUpgrades = false;
        GameManager.instance.isRefreshNeeded = false;
    }
}
