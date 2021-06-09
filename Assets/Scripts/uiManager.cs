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
    public GameObject mainMenu;
    public GameObject optionsMenu;
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate",4.0f,0.2f);

        Scene scene_name = SceneManager.GetActiveScene();
        Debug.Log("aktif sahne" + scene_name);
    }

    void Update()
    {
        if(scoreText != null){
            scoreText.text = "Score: "+ score;
        }
        
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
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;                                           
    }

    public void Menu(){
        SceneManager.LoadScene("MenuScene");   // menude arac secımı olsun (2 arac) araca gore ses de degıssın
    }
    public void Options(){
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }

    public void Pause(){
        if (Time.timeScale == 1 && audioManager.carSound.isPlaying == true){
            Time.timeScale = 0;
            audioManager.carSound.Stop();
            ui.gameOverActiveted();
        }
        else if(Time.timeScale == 1 && audioManager.maxSpeedSound.isPlaying == true){
            Time.timeScale = 0;
            audioManager.maxSpeedSound.Stop();
            ui.gameOverActiveted();
        }
        else if(Time.timeScale == 0 && audioManager.carSound.isPlaying == false){
            Time.timeScale = 1;
            gameOver = false;
            audioManager.maxSpeedSound.Play();
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
    public void BackButton(){
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
