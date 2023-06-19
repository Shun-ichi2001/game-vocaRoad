using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text countText;

    void Start()
    {
        countText.text = GManager.instance.timer2.ToString("f2");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
