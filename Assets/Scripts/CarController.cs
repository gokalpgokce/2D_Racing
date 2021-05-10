using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos;
    Vector3 position;
    public AudioManager audioManager;
    public bool maxSpeedSoundCheck = false;
    public uiManager ui;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.carSound.Play();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x,-maxPos,maxPos);
        transform.position = position;
        if(audioManager.carSound.isPlaying == false && maxSpeedSoundCheck == false && Time.timeScale == 1){
            maxSpeedSound();
        }
    }
    public void maxSpeedSound (){
        audioManager.maxSpeedSound.Play();
        maxSpeedSoundCheck = true;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
        if(col.gameObject.tag == "Enemy Car"){
            Destroy(gameObject);
            ui.gameOverActiveted();
            audioManager.carSound.Stop();
            audioManager.maxSpeedSound.Stop();
            Time.timeScale = 0;
            // arac carptiginda crash ses efekti eklenmeli.
        }
        
    }
}
