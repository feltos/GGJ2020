using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenToy : MonoBehaviour
{
    bool repairStart = false;
    float repairTime = 0.0f;
    float repairPeriod = 3.0f;
    //which player collide

    void Start()
    {
        
    }

    void Update()
    {
        if(repairStart)
        {
            repairTime += Time.deltaTime;
        }
        if(repairTime >= repairPeriod)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>().GetKeyPower() == 0)
        {
            Repair();
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>().GetKeyPower() != 0)
        {
            Destroy(gameObject);
        }
    }

    void Repair()
    {
        repairTime = 0.0f;
        repairStart = true;
    }

}
