//MicAudioSource.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Audio : MonoBehaviour
{

    static readonly int SAMPLE_RATE = 48000;

    static readonly float MOVING_AVE_TIME = 0.05f;


    static readonly int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);

    AudioSource micAS = null;

    
    private float _now_dB;
    public float now_dB { get { return _now_dB; } }

    private void Awake()
    {
        micAS = GetComponent<AudioSource>();
    }

    void Start()
    {
 
        this.MicStart();
    }

    public void MicStart()
    {

        micAS.clip = Microphone.Start(null, true, 1, SAMPLE_RATE);

        while (!(Microphone.GetPosition("") > 0)) { }

        micAS.Play();
    }

    void Update()
    {
        if (micAS.isPlaying)
        {

            float[] data = new float[MOVING_AVE_SAMPLE];

            micAS.GetOutputData(data, 0);

            float aveAmp = data.Average(s => Mathf.Abs(s));

            float dB = 20.0f * Mathf.Log10(aveAmp);

            _now_dB = dB;

        }
    }
}
