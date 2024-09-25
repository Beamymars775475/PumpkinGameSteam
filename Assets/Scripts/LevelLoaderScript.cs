using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{


    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame

    void Update()
    {
        if(GameManager.instance.goNextFloor == true)
        {
            LoadNextLevel();
            GameManager.instance.goNextFloor = false;
            GameManager.instance.isFloorClear = false;
            GameManager.instance.isGameOver = false;

        }
    }
    
    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().name == "UpgradeScene")
        {
            StartCoroutine(LoadLevel("GameScene" + (GameManager.instance.currentLevel+2))); // placeholder -> +1

        }
        else
        {
            StartCoroutine(LoadLevel("UpgradeScene"));
        }
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds (transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
    
