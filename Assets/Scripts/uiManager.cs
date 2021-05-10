using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Button[] buttons;
    public Text scoreText;
    bool gameOver;
    int score;
    public AudioManager audioManager;
    public CarController CarController;
    public uiManager ui;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate",4.0f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+ score;
    }

    void scoreUpdate(){
        if (gameOver == false){
            score += 1;
        }
    }

    public void gameOverActiveted(){
        gameOver = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Play(){
        SceneManager.LoadScene("SampleScene");  // menuscene de bu fonksiyonu kullaniyor. 
                                                //score play tusunun altinda artmaya devam ediyor fakat gorunmez hale getirdim.
                                                //hic olmamasi nasil saglarir?
    }

    public void Menu(){
        SceneManager.LoadScene("MenuScene");   // menude arac secımı olsun (2 arac) araca gore ses de degıssın
    }
    public void Exit(){
        Application.Quit();
    }

    public void Pause(){
        if (Time.timeScale == 1 && audioManager.carSound.isPlaying == true){
            Time.timeScale = 0;
            audioManager.carSound.Stop();
        }
        else if(Time.timeScale == 1 && audioManager.maxSpeedSound.isPlaying == true){
            Time.timeScale = 0;
            audioManager.maxSpeedSound.Stop();
        }
        else if(Time.timeScale == 0 && audioManager.carSound.isPlaying == false){
            Time.timeScale = 1;
            audioManager.carSound.Play();
        }
    }
}
