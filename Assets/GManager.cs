using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int stage;
    public int stageNum;
    public int continueNum;
    public  float timer = 0.0f;
    public float timer2;
    void Update()
    {
        timer += Time.deltaTime;
        timer2 = timer;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            Destroy(this.gameObject);
        }
    }
}
