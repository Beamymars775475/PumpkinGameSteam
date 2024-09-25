using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePrefabScript : MonoBehaviour
{

    public TMP_Text upgrade_textName;
    public TMP_Text upgrade_textUpgrade;
    public TMP_Text upgrade_textPrice;
    public int indexUpgrade;
    public int nb_tag_up;
    public double price;
    public double[] upgradeMultiplicator;
    public int[] upgradePrice;

    public int upgradeLevel;
    public Texture[] upgradeLevelSprite;

    public RectTransform upgrade_rect;
    
    public TextMeshProUGUI TMP_TextBank;

    public RawImage displayUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gb = GameObject.FindGameObjectWithTag("Banktext");
        TMP_TextBank = gb.GetComponent<TextMeshProUGUI>();

        GameManager.instance.UpdateTextNumber(TMP_TextBank, GameManager.instance.coinBank);
        
        if(nb_tag_up == 0)
        {
            upgrade_textName.text = "Score multiplicator";
            price = 100;
            upgrade_textPrice.text = price.ToString();
            upgrade_rect.anchoredPosition = new Vector3(-600, 300, gameObject.transform.position.z);

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.00; 
            upgradeMultiplicator[1] = 1.1;
            upgradeMultiplicator[2] = 1.25; 
            upgradeMultiplicator[3] = 1.5; 
            upgradeMultiplicator[4] = 2.25; 
            upgradeMultiplicator[5] = 3.5;

            upgradePrice = new int[6];
            upgradePrice[0] = 100; 
            upgradePrice[1] = 250;
            upgradePrice[2] = 750; 
            upgradePrice[3] = 1000; 
            upgradePrice[4] = 2000; 
            upgradePrice[5] = 5000;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 1)
        {
            upgrade_textName.text = "Upgrade 2";
            upgrade_textPrice.text = "125";
            upgrade_rect.anchoredPosition = new Vector3(-600, -20, gameObject.transform.position.z);
    
            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 10; 
            upgradeMultiplicator[1] = 15;
            upgradeMultiplicator[2] = 20; 
            upgradeMultiplicator[3] = 25; 
            upgradeMultiplicator[4] = 30; 
            upgradeMultiplicator[5] = 35;

            upgradePrice = new int[6];
            upgradePrice[0] = 125; 
            upgradePrice[1] = 500;
            upgradePrice[2] = 850; 
            upgradePrice[3] = 1650; 
            upgradePrice[4] = 2750; 
            upgradePrice[5] = 8500;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 2)
        {
            upgrade_textName.text = "Upgrade 3";
            upgrade_textPrice.text = "350";
            upgrade_rect.anchoredPosition = new Vector3(-600, -340, gameObject.transform.position.z);
    
            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.00; 
            upgradeMultiplicator[1] = 1.1;
            upgradeMultiplicator[2] = 1.25; 
            upgradeMultiplicator[3] = 1.5; 
            upgradeMultiplicator[4] = 2.25; 
            upgradeMultiplicator[5] = 3.5;

            upgradePrice = new int[6];
            upgradePrice[0] = 350; 
            upgradePrice[1] = 500;
            upgradePrice[2] = 750; 
            upgradePrice[3] = 3000; 
            upgradePrice[4] = 5000; 
            upgradePrice[5] = 10000;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString(); 

            return;
        }
        if(nb_tag_up == 3)
        {
            upgrade_textName.text = "Upgrade 4";
            upgrade_textPrice.text = "150";
            upgrade_rect.anchoredPosition = new Vector3(0, 300, gameObject.transform.position.z);

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.00; 
            upgradeMultiplicator[1] = 1.05;
            upgradeMultiplicator[2] = 1.1; 
            upgradeMultiplicator[3] = 1.25; 
            upgradeMultiplicator[4] = 1.5; 
            upgradeMultiplicator[5] = 2.00;

            upgradePrice = new int[6];
            upgradePrice[0] = 150; 
            upgradePrice[1] = 1250;
            upgradePrice[2] = 3000; 
            upgradePrice[3] = 5000; 
            upgradePrice[4] = 10000; 
            upgradePrice[5] = 20000;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 4)
        {
            upgrade_textName.text = "Upgrade 5";
            upgrade_textPrice.text = "250";
            upgrade_rect.anchoredPosition = new Vector3(0, -20, gameObject.transform.position.z);       

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.00; 
            upgradeMultiplicator[1] = 1.05;
            upgradeMultiplicator[2] = 1.1; 
            upgradeMultiplicator[3] = 1.2; 
            upgradeMultiplicator[4] = 1.35; 
            upgradeMultiplicator[5] = 1.5;  

            upgradePrice = new int[6];
            upgradePrice[0] = 250; 
            upgradePrice[1] = 500;
            upgradePrice[2] = 1000; 
            upgradePrice[3] = 3000; 
            upgradePrice[4] = 10000; 
            upgradePrice[5] = 25000;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 5)
        {
            upgrade_textName.text = "Upgrade 6";
            upgrade_textPrice.text = "150";
            upgrade_rect.anchoredPosition = new Vector3(0, -340, gameObject.transform.position.z);

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.01; 
            upgradeMultiplicator[1] = 1.025;
            upgradeMultiplicator[2] = 1.05; 
            upgradeMultiplicator[3] = 1.075; 
            upgradeMultiplicator[4] = 1.125; 
            upgradeMultiplicator[5] = 3.5;

            upgradePrice = new int[6];
            upgradePrice[0] = 150; 
            upgradePrice[1] = 275;
            upgradePrice[2] = 650; 
            upgradePrice[3] = 1500; 
            upgradePrice[4] = 5000; 
            upgradePrice[5] = 13500;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 6)
        {
            upgrade_textName.text = "Upgrade 7";
            upgrade_textPrice.text = "150";
            upgrade_rect.anchoredPosition = new Vector3(600, 300, gameObject.transform.position.z);

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.01; 
            upgradeMultiplicator[1] = 1.025;
            upgradeMultiplicator[2] = 1.05; 
            upgradeMultiplicator[3] = 1.075; 
            upgradeMultiplicator[4] = 1.125; 
            upgradeMultiplicator[5] = 3.5;

            upgradePrice = new int[6];
            upgradePrice[0] = 150; 
            upgradePrice[1] = 275;
            upgradePrice[2] = 650; 
            upgradePrice[3] = 1500; 
            upgradePrice[4] = 5000; 
            upgradePrice[5] = 13500;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;
        }
        if(nb_tag_up == 7)
        {
            upgrade_textName.text = "Upgrade 8";
            upgrade_textPrice.text = "125";
            upgrade_rect.anchoredPosition = new Vector3(600, -20, gameObject.transform.position.z);

            upgradeMultiplicator = new double[6];
            upgradeMultiplicator[0] = 1.10; 
            upgradeMultiplicator[1] = 1.25;
            upgradeMultiplicator[2] = 1.50; 
            upgradeMultiplicator[3] = 1.5; 
            upgradeMultiplicator[4] = 1.75; 
            upgradeMultiplicator[5] = 2.25;

            upgradePrice = new int[6];
            upgradePrice[0] = 125; 
            upgradePrice[1] = 1000;
            upgradePrice[2] = 2500; 
            upgradePrice[3] = 5000; 
            upgradePrice[4] = 10000; 
            upgradePrice[5] = 17500;

            upgrade_textUpgrade.text = upgradeMultiplicator[0].ToString() + " -> " + upgradeMultiplicator[1].ToString();

            return;

        }

    }

    // Update is called once per frame
    void Update() 
    {
        if(price == 0 || GameManager.instance.isNeedToReloadUpgrade)
        {
            upgradeLevel = GameManager.instance.upgrade_level[nb_tag_up-1]; // !!!
            displayUpgrades.texture = upgradeLevelSprite[upgradeLevel];
            GameManager.instance.isNeedToReloadUpgrade = false;
            price = upgradePrice[upgradeLevel];

            if(upgradeLevel != 5)
            {
                upgrade_textUpgrade.text = upgradeMultiplicator[upgradeLevel].ToString() + " -> " + upgradeMultiplicator[upgradeLevel+1].ToString();
                upgrade_textPrice.text = upgradePrice[upgradeLevel].ToString();
            } 
            else
            {
                upgrade_textUpgrade.text = upgradeMultiplicator[upgradeLevel].ToString() + " : MAX" ;
                upgrade_textPrice.text = "MAXED";
            }
        }

    }

    public void WhenClick()
    {
        BuyUpgrade();
    }

    void BuyUpgrade()
    {

        price = upgradePrice[upgradeLevel];
        if(price<GameManager.instance.coinBank && upgradeLevel != 5) // mettre un =
        {
            GameManager.instance.coinBank -= (int)price;
            GameManager.instance.UpdateTextNumber(TMP_TextBank, GameManager.instance.coinBank); 

            upgradeLevel++;
            print(nb_tag_up);
            if(nb_tag_up != 0)
            {
                GameManager.instance.upgrade_level[nb_tag_up-1] = upgradeLevel; // !!!
            }
            else
            {
                GameManager.instance.upgrade_level[nb_tag_up] = upgradeLevel;
            }
            
            

            displayUpgrades.texture = upgradeLevelSprite[upgradeLevel];

            // if(nb_tag_up == 1)
            // {
                // GameManager.instance.upgrade_score_multi_info = upgradeMultiplicator[upgradeLevel];
            // }

            if(upgradeLevel != 5)
            {
                upgrade_textUpgrade.text = upgradeMultiplicator[upgradeLevel].ToString() + " -> " + upgradeMultiplicator[upgradeLevel+1].ToString();
                upgrade_textPrice.text = upgradePrice[upgradeLevel].ToString();            
            }
        
            else if(upgradeLevel == 5)
            {
                upgrade_textUpgrade.text = upgradeMultiplicator[upgradeLevel].ToString() + " : MAX" ;
                upgrade_textPrice.text = "MAXED";
            }
        }
    }
}
