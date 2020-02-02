using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float randomX;
    float randomY;
    float randomZ;
    int brokentToysSpawn = 0;
    [SerializeField]GameObject brokenToy;
    float spawnTimer;
    float SpawnPeriod = 3.0f;

    [SerializeField] GameObject bonus;
    [SerializeField] int bonusPop;

    void Start()
    {
        
    }

    void Update()
    {
        randomZ = Random.Range(-5.25f, 9.0f);
        randomX = Random.Range(0.5f, -14f);
        randomY = Random.Range(5,10);
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= SpawnPeriod)
        {
            InstantiateBrokentToy();
        }
    }

    void InstantiateBrokentToy()
    {
        if (brokentToysSpawn >= bonusPop)
        {
            Instantiate(bonus, new Vector3(randomX, randomY, randomZ), brokenToy.transform.rotation);
            brokentToysSpawn = 0;
            spawnTimer = 0.0f;
            return;
        }
        if (brokentToysSpawn != bonusPop)
        {
            Instantiate(brokenToy, new Vector3(randomX, randomY, randomZ), brokenToy.transform.rotation);
            brokentToysSpawn++;
            spawnTimer = 0.0f;
        }
    }
}
