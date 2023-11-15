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
    float speed = 0.1f;
    void Start()
    {
        transform.position = new Vector2(0, 6);
    }

    void Update()
    {
        Vector2 movement = new Vector2(speed, 0);
        while(transform.position.y >= 3){
        transform.Translate(movement * Time.deltaTime); 
        }
    }
}
