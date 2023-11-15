using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject fiendePrefab;
    [SerializeField]
    GameObject bossPrefab;

    [SerializeField]
    float timeBetweenFiende = 1.5f;
    float timeSinceLastFiende = 0;
    Boolean BossSpawned;
    int Enemyspawnedsinceboss;
    void Update()
    {
            timeSinceLastFiende += Time.deltaTime;
            if(timeSinceLastFiende > timeBetweenFiende){
                Instantiate(fiendePrefab);
                timeSinceLastFiende = 0;
                Enemyspawnedsinceboss += 1;
            }
            if(Enemyspawnedsinceboss >= 5){
                Instantiate(bossPrefab);
                BossSpawned = true;
                Enemyspawnedsinceboss = 0;
            }
            if(BossSpawned){
                timeSinceLastFiende = 0;
            }


    }
}
