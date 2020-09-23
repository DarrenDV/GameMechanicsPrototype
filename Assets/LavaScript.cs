using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camera;
    public Vector3 ResetPos;
    public Quaternion ResetRotation;

    // Start is called before the first frame update
    void Start()
    {   
        ResetPos = Player.transform.position;
        ResetRotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player){
            Player.transform.position = ResetPos;
            Camera.transform.rotation = ResetRotation;
        }
    }
}
