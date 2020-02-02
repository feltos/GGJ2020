using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour
{
    float rightStickHor;
    float rightStickVer;
    Vector3 dir;
    public string vertical;
    public string horizontal;

    [SerializeField]Camera camera;
    
    void Update()
    {
        rightStickHor = Input.GetAxis(horizontal);
        rightStickVer = Input.GetAxis(vertical);
        dir = new Vector3(rightStickHor, 0,rightStickVer);
        transform.LookAt(transform.position + dir);
    }
}

