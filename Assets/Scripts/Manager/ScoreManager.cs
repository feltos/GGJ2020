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

    void Start()
    {
        scoreBro.text = broValue.ToString();
        scoreKen.text = kenValue.ToString();
    }

    void Update()
    {
        scoreBro.text = broValue.ToString();
        scoreKen.text = kenValue.ToString();
    }
}
