using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource carSound;
    public AudioSource maxSpeedSound;
    public Toggle isMute;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       soundToggle(isMute.isOn);
    }

    public void soundToggle (bool isMute){
        if(isMute == true){
            AudioListener.volume = 1;
        }
        else if (isMute == false){
            AudioListener.volume = 0;
        }
    }

}
