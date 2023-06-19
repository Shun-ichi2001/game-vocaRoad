using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagectrl : MonoBehaviour
{
    [Header("player")] public GameObject playerObj;
   [Header("continue")] public GameObject[] continuePoint;
    public static float timer = 0.0f;

    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0)
        {
            playerObj.transform.position = continuePoint[0].transform.position;
        }
        else
        {
            
        }
    }

    
}
