using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        body = GetComponent<Rigidbody>();
        weaponKey.enabled = false;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Mouse0))
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
    }
}
