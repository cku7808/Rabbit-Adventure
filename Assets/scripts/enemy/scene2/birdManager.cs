using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    int birdSpeed = 10;
    playerMove player;
    Vector3 pos = new Vector3(258,20.5f,41);
    float max = 0.17f;

    void Start()
    {
        player = GameObject.Find("player2").GetComponent<playerMove>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
// Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 71)
        {
            transform.position += Vector3.left * Time.deltaTime * birdSpeed;
            transform.position += Vector3.up*max * Mathf.Sin(Time.time*3);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("birdDestroy"))
        {
            Destroy(gameObject);
        }
    }

}   
