using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    public GameObject Bomb;
    public float power = 100000000f;
    public float radius = 100f;
    public float upForce = 100000f;

    [SerializeField] GameObject barrelExplosion;


    private void Start()
    {
        Bomb = this.gameObject;

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Detonate();
        }
    }

    void Detonate()
    {
        Vector3 explosionPosition = Bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                barrelExplosion.SetActive(true);
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                Destroy(Bomb);
            }
        }
    }
}
