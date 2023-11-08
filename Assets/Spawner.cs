using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject fiendePrefab;

    [SerializeField]
    float timeBetweenFiende = 1.5f;
    float timeSinceLastFiende = 0;
    Boolean BossSpawned = false;
    void Update()
    {
            timeSinceLastFiende += Time.deltaTime;
            if(timeSinceLastFiende > timeBetweenFiende){
            Instantiate(fiendePrefab);
                timeSinceLastFiende = 0;
            }
            if(BossSpawned){
                timeSinceLastFiende = 0;
            }


    }
}
