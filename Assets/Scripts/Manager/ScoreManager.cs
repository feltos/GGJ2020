using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]Image bro;
    [SerializeField] Image ken;

    [SerializeField] Text scoreBro;
    [SerializeField] Text scoreKen;

    int broValue = 0;
    int kenValue = 0;

    [SerializeField] int scoreToWin;
    [SerializeField] Text victoryText;

    enum Leader
    {
        EQUAL,
        BRO,
        KEN,
    }
    Leader leader = Leader.EQUAL;

    void Start()
    {
        scoreBro.text = broValue.ToString();
        scoreKen.text = kenValue.ToString();
    }

    void Update()
    {
        scoreBro.text = broValue.ToString();
        scoreKen.text = kenValue.ToString();
        

        switch(leader)
        {
            case Leader.EQUAL:
                //Change image
                if(kenValue > broValue)
                {
                    leader = Leader.KEN;
                }
                if (broValue > kenValue)
                {
                    leader = Leader.BRO;
                }               
                break;

            case Leader.BRO:
                //Change image
                if(broValue == kenValue)
                {
                    leader = Leader.EQUAL;
                }
                if(broValue >= scoreToWin)
                {
                    victoryText.text = "BRO";
                    victoryText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                    //Victory screen
                }
                break;

            case Leader.KEN:
                //Change image
                if (kenValue == broValue)
                {
                    leader = Leader.EQUAL;
                }
                if (kenValue >= scoreToWin)
                {
                    victoryText.text = "KEN";
                    victoryText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                    //Victory screen
                }
                break;
        }
    }

    public void SetScore(int playerIndex)
    {
        if(playerIndex == 0)
        {
            broValue += 10;
        }
        if(playerIndex == 1)
        {
            kenValue += 10;
        }
    }
}
