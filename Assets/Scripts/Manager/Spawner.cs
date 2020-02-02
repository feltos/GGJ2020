using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int randomX;
    int randomY;
    int randomZ;
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
        randomZ = Random.Range(-5, 8);
        randomX = Random.Range(4, -14);
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
