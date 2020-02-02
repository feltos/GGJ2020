using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            GetComponent<Animation>().Play("Hit");

        }
        else {

            GetComponent<Animation>().Play("Run");
            GetComponent<Animation>().wrapMode = WrapMode.Loop;


        }

    }
}
