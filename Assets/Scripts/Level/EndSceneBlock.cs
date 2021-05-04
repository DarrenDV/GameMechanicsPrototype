using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneBlock : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player){
            gameManager.endBlockCollision = true;
        }
    }
}
