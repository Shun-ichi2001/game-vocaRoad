using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    private bool firstPush = false;

    public void PressStart()
    {
        
        if (!firstPush)
        {
          
           
            SceneManager.LoadScene("stage2");
            
            firstPush = true;
        }
    }
}
