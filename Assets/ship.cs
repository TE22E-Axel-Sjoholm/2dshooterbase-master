using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ship : MonoBehaviour
{
    [SerializeField]
    float speed = 4.1f;

    [SerializeField]
    GameObject skottPrefab;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    float timeBetweenShots = 0.5f;
    float timeSinceLastShot = 0;

    [SerializeField]
    Slider healthbar;

    public int healthCurrent;
    [SerializeField]
    int healthMax = 3;

    void Start()
    {
        healthCurrent = healthMax;
        healthbar.maxValue = healthMax;
        healthbar.value = healthMax;
    }
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movementX = new Vector2(moveX, 0);
        Vector2 movementY = new Vector2(0, moveY);
        Vector2 movement = movementX + movementY;
        transform.Translate(movement * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.y) > 4.25)
        {
            transform.Translate(-movementY * speed * Time.deltaTime);
        }
        if (Mathf.Abs(transform.position.x) > 9.7)
        {
            transform.Translate(-movementX * speed * Time.deltaTime);
        }

        timeSinceLastShot += Time.deltaTime;


        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            Instantiate(skottPrefab, gun.transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }


    }

    public void Hurt(int amount)
    {
        healthCurrent -= amount;
        healthbar.value = healthCurrent;
        if (healthCurrent == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Hurt(1);
        }
    }
}