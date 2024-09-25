using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Transform transformComboCursor;

    void Start()
    {

    }

    void Update()
    {
        GetCurrentFill();
    }
    
    void GetCurrentFill()
    {
        float currentOffset = (float)current - (float)minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        transformComboCursor.rotation = Quaternion.Euler(transformComboCursor.rotation.x, transformComboCursor.rotation.y, fillAmount*-360);
    }
}
