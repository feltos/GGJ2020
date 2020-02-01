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

    void Start()
    {
        
    }

    void Update()
    {
        randomZ = Random.Range(-11, 3);
        randomX = Random.Range(-6, 8);
        randomY = Random.Range(25,30);
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= SpawnPeriod)
        {
            InstantiateBrokentToy();
        }
    }

    void InstantiateBrokentToy()
    {
        Instantiate(brokenToy, new Vector3(randomX, randomY, randomZ), brokenToy.transform.rotation);
        brokentToysSpawn++;
        if(brokentToysSpawn >= 5)
        {
            //Instantiate()
        }
        spawnTimer = 0.0f;
    }
}
