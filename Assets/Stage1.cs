using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    private bool firstPush = false;

    public void PressStart()
    {
        
        if (!firstPush)
        {
            
            
            SceneManager.LoadScene("stage1");
            
            firstPush = true;
        }
    }
}
