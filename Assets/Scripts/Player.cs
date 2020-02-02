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
    public string verticalAxis;
    public string horizontalAxis;
    public string keyHit;

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
        LOW_OPACITY,
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
    bool speedDownBool = false;

    //REDUCE OPACITY
    Material basicMaterial;
    [SerializeField]Material invisible;
    float invisibleTimer = 0.0f;
    [SerializeField]float invisiblePeriod;

    //BOOST_KEY
    int keyPower = 0;
    int basicKeyPower;
    int boostKeyPower = 1;
    float boostTimer = 0.0f;
    [SerializeField]float boostPeriod;


    void Start()
    {
        basicMaterial = GetComponent<MeshRenderer>().material;
        body = GetComponent<Rigidbody>();
        weaponKey.enabled = false;
        basicSpeed = speed;
        enemiesPlayer = GameObject.FindObjectsOfType<Player>();
        basicKeyPower = keyPower;
    }

    void Update()
    {
        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);

        if (Input.GetButtonDown(keyHit))
        {
            hit = true;
            hitTimer = 0.0f;
            weaponKey.enabled = true;
        }
        switch (bonus)
        {
            case BonusMalus.NOTHING:
                speedUpTimer = 0.0f;
                speed = basicSpeed;
                stunTimer = 0.0f;
                speedDownTimer = 0.0f;
                GetComponent<MeshRenderer>().material = basicMaterial;
                invisibleTimer = 0.0f;
                boostTimer = 0.0f;
                keyPower = basicKeyPower;
                speedDownBool = false;
                break;

            case BonusMalus.SPEED_UP:
                speed = newSpeed;
                speedUpTimer += Time.deltaTime;
                if (speedUpTimer > speedUpPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.BOOST_KEY:
                keyPower = boostKeyPower;
                boostTimer += Time.deltaTime;
                if (boostTimer >= boostPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.STUN_ALL:
                foreach (Player player in enemiesPlayer)
                {
                    if (player.playerIndex != this.playerIndex)
                    {
                        player.bonus = BonusMalus.STUN;
                    }
                }
                bonus = BonusMalus.NOTHING;
                break;

            case BonusMalus.STUN:
                stunTimer += Time.deltaTime;
                speed = 0;
                //ANIM STUN
                if (stunTimer > stunPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.SPEED_DOWN_ALL:
                foreach (Player player in enemiesPlayer)
                {
                    player.speed = speedDown;
                    player.speedDownBool = true;
                }
                speedDownTimer += Time.deltaTime;
                if (speedDownTimer >= speedDownPeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;

            case BonusMalus.REDUCE_OPACITY:
                foreach (Player player in enemiesPlayer)
                {
                    if (player.playerIndex != this.playerIndex)
                    {
                        player.bonus = BonusMalus.LOW_OPACITY;
                    }
                    else
                    {
                        bonus = BonusMalus.NOTHING;
                    }
                }
                break;

            case BonusMalus.LOW_OPACITY:
                GetComponent<MeshRenderer>().material = invisible;
                invisibleTimer += Time.deltaTime;
                if (invisibleTimer >= invisiblePeriod)
                {
                    bonus = BonusMalus.NOTHING;
                }
                break;
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector3(speed * horizontal, 0, speed * vertical); ;
        if(body.velocity.x == 0 && body.velocity.z == 0 && bonus != BonusMalus.STUN)
        {
            //ANIM IDLE
            Debug.Log("Didn't move");
        }
        if ((body.velocity.x != 0 || body.velocity.z != 0) && bonus != BonusMalus.STUN)
        {
            //ANIM RUN
            Debug.Log("RUN");
        }
        if (hit)
        {
            //ANIM HIT
            hitTimer += Time.deltaTime;
        }
        if (hitTimer > hitPeriod)
        {
            weaponKey.enabled = false;
            hit = false;
        }
       
    }

    public int GetKeyPower()
    {
        return keyPower;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            BonusPin bonusPin = collision.gameObject.GetComponent<BonusPin>();
            Debug.Log(bonusPin.GetBonusType(bonusPin));
            if(!speedDownBool)
            {
                if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.SPEED_UP)
                {
                    bonus = BonusMalus.SPEED_UP;
                    Destroy(collision.gameObject);
                }
                if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.BOOST_KEY)
                {
                    bonus = BonusMalus.BOOST_KEY;
                    Destroy(collision.gameObject);
                }
                if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.STUN_ALL)
                {
                    bonus = BonusMalus.STUN_ALL;
                    Destroy(collision.gameObject);
                }
                if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.SPEED_DOWN_ALL)
                {
                    bonus = BonusMalus.SPEED_DOWN_ALL;
                    Destroy(collision.gameObject);
                }
                if (bonusPin.GetBonusType(bonusPin) == BonusPin.BonusType.REDUCE_OPACITY)
                {
                    bonus = BonusMalus.REDUCE_OPACITY;
                    Destroy(collision.gameObject);
                }
            }


        }
    }

}
