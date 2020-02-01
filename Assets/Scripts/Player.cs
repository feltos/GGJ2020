using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;

    Rigidbody body;
    Vector3 mouseDirection;
    Vector2 movement;
    [SerializeField]float speed;

    Vector3 mousePosition;
    float mouseInput;

    [SerializeField] BoxCollider weaponKey;
    float hitTimer = 0.0f;
    float hitPeriod = 0.05f;
    bool hit = false;
    

    enum BonusMalus
    {
        NOTHING,
        SPEED_UP,
        BOOST_KEY,
        STUN_ALL,
        STUN,
        SPEED_DOWN_ALL,
        REDUCE_OPACITY,
    }
    BonusMalus bonus = BonusMalus.NOTHING;

    [SerializeField] int playerIndex;
    Player[] enemiesPlayer;

    //SPEED_UP
    float basicSpeed;
    [SerializeField]float newSpeed;
    float speedUpTimer = 0.0f;
    [SerializeField]float speedUpPeriod;

    //STUN_ALL
    float stunTimer = 0.0f;
    [SerializeField] float stunPeriod;

    //SPEED_DOWN
    float speedDownTimer = 0.0f;
    [SerializeField] float speedDownPeriod;
    [SerializeField] float speedDown;

    //REDUCE OPACITY
    Material basicMaterial;
    [SerializeField]Material invisible;
    float invisibleTimer = 0.0f;
    [SerializeField]float invisiblePeriod;


    void Start()
    {
        basicMaterial = GetComponent<MeshRenderer>().material;
        body = GetComponent<Rigidbody>();
        weaponKey.enabled = false;
        basicSpeed = speed;
        enemiesPlayer = GameObject.FindObjectsOfType<Player>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hit = true;
            hitTimer = 0.0f;
            weaponKey.enabled = true;
        } 
    }

    void FixedUpdate()
    {
        body.velocity = new Vector3(speed * horizontal, 0, speed * vertical); ;

        if (hit)
        {
            hitTimer += Time.deltaTime;
        }
        if (hitTimer > hitPeriod)
        {
            weaponKey.enabled = false;
            hit = false;
        }
        switch(bonus)
        {
            case BonusMalus.NOTHING:
                speedUpTimer = 0.0f;
                speed = basicSpeed;
                stunTimer = 0.0f;
                speedDownTimer = 0.0f;
                GetComponent<MeshRenderer>().material = basicMaterial;
                invisibleTimer = 0.0f;
                Debug.Log("NOTHING");
                break;

            case BonusMalus.SPEED_UP:
                speed = newSpeed;
                speedUpTimer += Time.deltaTime;
                if(speedUpTimer > speedUpPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.BOOST_KEY:
                break;

            case BonusMalus.STUN_ALL:
                foreach(Player player in enemiesPlayer)
                {
                    if(player.playerIndex != this.playerIndex)
                    {
                        player.bonus = BonusMalus.STUN;
                    }
                }
                bonus = BonusMalus.NOTHING;
                break;

            case BonusMalus.STUN:
                stunTimer += Time.deltaTime;
                speed = 0;
                if(stunTimer > stunPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.SPEED_DOWN_ALL:
                foreach (Player player in enemiesPlayer)
                {
                    player.speed = speedDown;                  
                }
                speedDownTimer += Time.deltaTime;
                if (speedDownTimer >= speedDownPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

                //TO REPAIR
            case BonusMalus.REDUCE_OPACITY:
                foreach (Player player in enemiesPlayer)
                {
                    if (player.playerIndex != this.playerIndex)
                    {
                        //reduce opacity
                        player.gameObject.GetComponent<MeshRenderer>().material = invisible;
                    }
                    else
                    {
                        bonus = BonusMalus.NOTHING;
                    }
                }
                break;
                //TO REPAIR
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            BonusPin bonusPin = collision.gameObject.GetComponent<BonusPin>();
            Debug.Log(bonusPin.GetBonusType(bonusPin));

            if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.SPEED_UP)
            {
                bonus = BonusMalus.SPEED_UP;
            }
            if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.BOOST_KEY)
            {
                bonus = BonusMalus.BOOST_KEY;
            }
            if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.STUN_ALL)
            {
                bonus = BonusMalus.STUN_ALL;
            }
            if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.SPEED_DOWN_ALL)
            {
                bonus = BonusMalus.SPEED_DOWN_ALL;
            }
            if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.REDUCE_OPACITY)
            {
                bonus = BonusMalus.REDUCE_OPACITY;
            }

        }
    }

}
