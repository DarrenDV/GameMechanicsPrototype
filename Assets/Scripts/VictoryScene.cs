using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{

    public GameManager gameManager;
    public Stopwatch stopwatch;

    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        stopwatch = GameObject.Find("GameManager").GetComponent<Stopwatch>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    void Update(){
        stopwatch.PauseTimer();
    }

    //Buttons used for switching scene / ending game
    public void RestartGame(){
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("Level 1");
    }
    
    public void BackToMainMenu(){
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame(){
        Application.Quit();
    }




}
