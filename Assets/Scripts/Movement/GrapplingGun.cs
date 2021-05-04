using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplepoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private SpringJoint joint;
    public float maxDistance = 100f;

    public GameObject gunshot;

    AudioSource audio;

    GameManager gameManager;
    bool canObtainSuccession = false;
    PlayerMovement pm;

    void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            gunshot.SetActive(true);
            audio.Play();
            StartGrapple();
            
        }
        else if(Input.GetMouseButtonUp(0)){
            gunshot.SetActive(false);
            StopGrapple();
            
        }
        CheckSuccession();
    }

    void LateUpdate(){
        DrawRope();
    }

    void StartGrapple(){
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)){
            grapplepoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplepoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplepoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
        }
        CheckSuccession(1);
    }

    void DrawRope(){
        if(!joint) return;
        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, grapplepoint);
    }

    public void StopGrapple(){
        canObtainSuccession = true;
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    void CheckSuccession(int extraCoin = 0)
    {
        if (canObtainSuccession && pm.grounded == true)
        {
            canObtainSuccession = false;
        }
        else if (canObtainSuccession && !pm.grounded && extraCoin == 1) 
        {
            gameManager.AddCoins();
            extraCoin = 0;
        }
    }

}
