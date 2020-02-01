using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour
{
    [SerializeField]Camera camera;
    // Update is called once per frame
    void Update()
    {
        var mousepos = Input.mousePosition;
        var playerpos = camera.WorldToScreenPoint(transform.position);
        var dir = mousepos - playerpos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}

