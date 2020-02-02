using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPin : MonoBehaviour
{

    [SerializeField]Material speed_up_material;
    [SerializeField] Material boost_key_material;
    [SerializeField] Material stun_all_material;
    [SerializeField] Material speed_down_material;
    [SerializeField] Material reduce_opacity_material;


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
        switch (bonusType)
        {
            case BonusType.SPEED_UP:
                this.gameObject.GetComponent<MeshRenderer>().material = speed_up_material;
                break;

            case BonusType.BOOST_KEY:
                this.gameObject.GetComponent<MeshRenderer>().material = boost_key_material;
                break;

            case BonusType.STUN_ALL:
                this.gameObject.GetComponent<MeshRenderer>().material = stun_all_material;
                break;

            case BonusType.SPEED_DOWN_ALL:
                this.gameObject.GetComponent<MeshRenderer>().material = speed_down_material;
                break;

            case BonusType.REDUCE_OPACITY:
                this.gameObject.GetComponent<MeshRenderer>().material = reduce_opacity_material;
                break;
        }

    }

    void Update()
    {
    
    }

    public BonusType GetBonusType(BonusPin bonusPin)
    {
        return bonusType;
    }
}
