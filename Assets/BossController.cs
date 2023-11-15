using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [SerializeField]
    GameObject expltionPrefab;
    [SerializeField]
    GameObject player;
    float speed = 1;
    Boolean right = true;
    Boolean left;
    void Start()
    {
        transform.position = new Vector2(0, 7);
    }

    void Update()
    {
        Vector2 movementY = new Vector2(speed, 0);
        Vector2 movementX = new Vector2(0, 2);
        if(transform.position.y >= 2.7){
        transform.Translate(movementY * Time.deltaTime); 
        }
        if(transform.position.x > 7.5){
            right = false;
            left = true;
        } 
        if(transform.position.x < -7.5){
            right = true;
            left = false;
        } 
        if(transform.position.y < 2.8 && transform.position.y > 2.6 && left){
            transform.Translate(-movementX * Time.deltaTime);
        }
        if(transform.position.y < 2.8 && transform.position.y > 2.6 && right){
            transform.Translate(movementX * Time.deltaTime);
        }

    }
}
