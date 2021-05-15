﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource carSound;
    public AudioSource maxSpeedSound;
    public Toggle muteToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        muteToggle.isOn = AudioListener.volume == 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void soundToggle (bool isMute){

        AudioListener.volume = muteToggle.isOn ? 1 : 0;
    }

}
