using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject Player;
    public GameManager GameManager;



    void Start()
    {
        Player = GameObject.Find("Player");
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            GameManager.CoinSound();
            GameManager.AddCoins();
            Destroy(gameObject);
        }
    }


}
