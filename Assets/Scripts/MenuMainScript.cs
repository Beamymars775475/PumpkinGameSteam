using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMainScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _col)
    {
        if(_col.gameObject.name == "ButtonPlay")
        {
            SceneManager.LoadScene("GameScene");
        }
        if(_col.gameObject.name == "ButtonQuit")
        {
            Application.Quit();
        }
        if(_col.gameObject.name == "ButtonShop")
        {
            SceneManager.LoadScene("ShopScene");

        }
        if(_col.gameObject.name == "ButtonSettings")
        {
            SceneManager.LoadScene("SettingsScene");

        }
    }
}
