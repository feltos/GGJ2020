using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool win = false;

    [SerializeField] GameObject victoryScreen;
    [SerializeField] Sprite broWinner;
    [SerializeField] Sprite kenWinner;

    float resultTimer;
    [SerializeField]float resultPeriod;

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
        scoreBro.text = broValue.ToString() + "/ " + scoreToWin;
        scoreKen.text = kenValue.ToString() + "/ " + scoreToWin;
        
        if(resultTimer >= resultPeriod)
        {
            SceneManager.LoadScene("Menu");
        }
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
                    Time.timeScale = 0.0f;
                    resultTimer += Time.unscaledDeltaTime;
                }
                if(broValue >= scoreToWin && !win)
                {
                    SoundFx.Instance.EndGameSound();
                    if (victoryScreen.GetComponent<Image>() != null)
                    {
                        victoryScreen.GetComponent<Image>().enabled = true;
                        victoryScreen.GetComponent<Image>().sprite = broWinner;
                    }
                    win = true;      
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
                if (kenValue >= scoreToWin && !win)
                {
                    SoundFx.Instance.EndGameSound();
                    if (victoryScreen.GetComponent<Image>() != null)
                    {
                        victoryScreen.GetComponent<Image>().enabled = true;
                        victoryScreen.GetComponent<Image>().sprite = kenWinner;
                    }
                    win = true;
                }
                if (kenValue >= scoreToWin)
                {
                    Time.timeScale = 0.0f;
                    resultTimer += Time.unscaledDeltaTime;
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
        SoundFx.Instance.ScoreSound();
    }
}
