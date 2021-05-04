using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMovement : MonoBehaviour
{

    public bool goingLeft, goingRight;

    void Update()
    {
        Vector3 temp = transform.rotation.eulerAngles;

        if (goingLeft)
        {
            if(transform.rotation.z < 30)
            {
                temp.z += 0.3f;
                transform.rotation = Quaternion.Euler(temp);
            }
        }
    }

}
