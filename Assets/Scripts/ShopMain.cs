using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMain : MonoBehaviour
{

    public UpgradePrefabScript upgradePrefab;

    public int score_multip = 1;
    public double[] upgrade1Multiplicator = {1.1, 1.25, 1.5, 2.25, 3.5};

    UpgradePrefabScript upgradeInstance;

    public TextMeshProUGUI textBankInShop;

    public Transform canvas;

    void Start()
    {
        GameManager.instance.UpdateTextNumber(textBankInShop, GameManager.instance.coinBank);
        NewUpgrade("Upgrade 1");
        NewUpgrade("Upgrade 2");
        NewUpgrade("Upgrade 3");
        NewUpgrade("Upgrade 4");
        NewUpgrade("Upgrade 5");
        NewUpgrade("Upgrade 6");
        NewUpgrade("Upgrade 7");

    }

    public void NewUpgrade(string nameUpgrade)
    {       
        upgradeInstance = GameObject.Instantiate<UpgradePrefabScript>(upgradePrefab);    
        upgradeInstance.name = nameUpgrade;
        upgradeInstance.transform.SetParent(canvas);
        upgradeInstance.upgrade_rect = upgradeInstance.GetComponent(typeof(RectTransform)) as RectTransform;
        GameObject[] gameobject_tag_upgrade = GameObject.FindGameObjectsWithTag("Upgrade");
        upgradeInstance.nb_tag_up = gameobject_tag_upgrade.Length-1;

    }

    public void BackToMainScene()
    {         
        SceneManager.LoadScene("MainScene");
    }
}
