using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPin : MonoBehaviour
{
    public enum BonusType
    {
        SPEED_UP = 0,
        BOOST_KEY = 1,
        STUN_ALL = 2,
        SPEED_DOWN_ALL = 3,
        REDUCE_OPACITY = 4,
        LENGTH = 5
    }
    BonusType bonusType = BonusType.BOOST_KEY;

    void Start()
    {
        bonusType = ((BonusType)Random.Range(0, 5));
        Debug.Log(bonusType.ToString());
    }

    void Update()
    {
        
    }

    public BonusType GetBonusType(BonusPin bonusPin)
    {
        return bonusType;
    }
}
