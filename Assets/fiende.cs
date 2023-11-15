using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fiende : MonoBehaviour
{

    [SerializeField]
    GameObject expltionPrefab;
    GameObject player;
    void Start()
    {
        transform.position = new Vector2(Random.Range(-10.0f, 10.0f), 6);
        player = GameObject.Find("Ship");
    }
    void Update()
    {
        Vector2 movement = new Vector2(1, 0);
        transform.Translate(movement * Time.deltaTime);

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
            player.GetComponent<ship>().Hurt(1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bolt" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(expltionPrefab, transform.position, Quaternion.identity);
        }
    }
}
