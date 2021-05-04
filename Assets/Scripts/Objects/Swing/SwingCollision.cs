using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public Vector3 ResetPos;
    public Quaternion ResetRotation;
    public GameObject GrapplingGun;
    void Start()
    {
        GrapplingGun = GameObject.Find("Gun");
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Camera");

        ResetPos = Player.transform.position;
        ResetRotation = new Quaternion(0, 0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            GrapplingGun.GetComponent<GrapplingGun>().StopGrapple();
            Player.transform.position = ResetPos;
            Camera.transform.rotation = ResetRotation;
        }
    }
}
