using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public bool endBlockCollision = false;
    public Stopwatch stopwatch;
    public Text coinText;


    public int coins;
    [Range(0, 4)]
    public float speedBoostMultiplier;
    public int coinCost;

    AudioSource audio;
    public static AudioClip coinSound, deathSound;

    #region Default

    void Awake(){
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        coinSound = Resources.Load<AudioClip>("mario_coin_sound");
        deathSound = Resources.Load<AudioClip>("DeathSound");
        stopwatch = this.gameObject.GetComponent<Stopwatch>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        SceneManagement();
        Assigning();
        UIupdate();
        Boosting();
    }

    void Assigning()
    {
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        Player = GameObject.Find("Player");
    }

    void UIupdate()
    {
        coinText.text = "Coins: " + coins;
    }

    void SceneManagement(){
        GoBackToMainMenu();
        QuickRestart();

        Scene scene = SceneManager.GetActiveScene();

        switch(scene.name){

            case "Level 1":
            if(endBlockCollision){
                SceneSwitcher("Level 2");
                endBlockCollision = false;
            }
            break;

            case "Level 2":
            if(endBlockCollision){
                SceneSwitcher("Level 3");
                endBlockCollision = false;
            }
            break;

            case "Level 3":
            if(endBlockCollision){
                SceneSwitcher("Level 4");
                endBlockCollision = false;
            }
            break;

            case "Level 4":
            if(endBlockCollision){
                SceneSwitcher("Level 5");
                endBlockCollision = false;
            }
            break;

            case "Level 5":
            if(endBlockCollision){
                SceneSwitcher("EndScene");
                endBlockCollision = false;
            }
            break;
        }
    }

    void SceneSwitcher(string sceneToSwitchTo){
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    //When escape is pressed, change scene to the startmenu and delete/reset everything not used anymore
    void GoBackToMainMenu(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            stopwatch.ResetTimer();
            SceneManager.LoadScene("TitleScreen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(this.gameObject);
        }
    }

    //Lets the player quickly restart the game by pressing a key
    void QuickRestart(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Level 1");
            Destroy(this.gameObject);
        }
    }

    #endregion

    public void AddCoins()
    {
        coins++;
    }

    void Boosting()
    {
        Rigidbody rb = Player.GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (coins >= coinCost)
            {
                coins -= coinCost;
                rb.velocity *= speedBoostMultiplier;
            }
        }
    }

    public void CoinSound()
    {
        audio.PlayOneShot(coinSound);
    }
    public void PlayDeathSound()
    {
        audio.PlayOneShot(deathSound);
    }
}
