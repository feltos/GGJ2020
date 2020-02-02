using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]Image bro;
    [SerializeField] Image ken;
    [SerializeField] Image broWin;
    [SerializeField] Image kenWin;
    [SerializeField] Image broLose;
    [SerializeField] Image kenLose;

    [SerializeField] Text scoreBro;
    [SerializeField] Text scoreKen;

    [SerializeField]Image[] broKen;

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

                foreach (Image image in broKen)
                {
                    image.gameObject.SetActive(false);
                }
                bro.gameObject.SetActive(true);
                ken.gameObject.SetActive(true);

                if (kenValue > broValue)
                {
                    leader = Leader.KEN;
                }
                if (broValue > kenValue)
                {
                    leader = Leader.BRO;
                }               
                break;

            case Leader.BRO:
                foreach (Image image in broKen)
                {
                    image.gameObject.SetActive(false);
                }

                broWin.gameObject.SetActive(true);
                kenLose.gameObject.SetActive(true);

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
                foreach (Image image in broKen)
                {
                    image.gameObject.SetActive(false);
                }
                kenWin.gameObject.SetActive(true);
                broLose.gameObject.SetActive(true);

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
