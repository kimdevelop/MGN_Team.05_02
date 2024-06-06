using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    
    void Update()
    {
        
    }

    void StopMusic()
    {
        AudioSource MusicStop = GetComponent<AudioSource> ();
        MusicStop.Stop();

    }
}
