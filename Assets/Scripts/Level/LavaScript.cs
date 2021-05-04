using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camera;
    public Vector3 ResetPos;
    public Quaternion ResetRotation;
    public GameObject GrapplingGun;
    public GameManager gameManager;

    void Start()
    {   
        GrapplingGun = GameObject.Find("Gun");
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Camera");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        ResetPos = Player.transform.position;
        ResetRotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player){
            gameManager.PlayDeathSound();
            GrapplingGun.GetComponent<GrapplingGun>().StopGrapple();
            Player.transform.position = ResetPos;
            Camera.transform.rotation = ResetRotation;
        }
    }
}
