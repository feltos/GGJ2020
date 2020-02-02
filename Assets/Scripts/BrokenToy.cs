using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrokenToy : MonoBehaviour
{
    bool repairStart = false;
    float repairTime = 0.0f;
    float repairPeriod = 3.0f;
    int playerIndex;
    ScoreManager scoreManager;
    [SerializeField]Behaviour blueHalo;
    [SerializeField]Behaviour RedHalo;


    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        
    }

    void Update()
    {
        if(repairStart)
        {
            repairTime += Time.deltaTime;
            if(playerIndex == 0)
            {
                blueHalo.enabled = true;
                RedHalo.enabled = false;
            }
            if(playerIndex == 1)
            {
                RedHalo.enabled = true;
                blueHalo.enabled = false;
            }

        }
        if(repairTime >= repairPeriod)
        {
            scoreManager.SetScore(playerIndex);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>().GetKeyPower() == 0)
        {
            playerIndex = collision.gameObject.GetComponent<Player>().playerIndex;
            Repair();
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>().GetKeyPower() != 0)
        {
            playerIndex = collision.gameObject.GetComponent<Player>().playerIndex;
            scoreManager.SetScore(playerIndex);
            Destroy(this.gameObject);
        }
    }

    void Repair()
    {
        repairTime = 0.0f;
        repairStart = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            SoundFx.Instance.BodyFallSound();
        }
    }

}
