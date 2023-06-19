using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{


    private bool firstPush = false;
    /*
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }
    */
    public void PressStart()
    {
        
        if (!firstPush)
        {
            //audioSource.PlayOneShot(sound1);
            
            
            SceneManager.LoadScene("chuto");
            
            firstPush = true;
            
        }
    }
}