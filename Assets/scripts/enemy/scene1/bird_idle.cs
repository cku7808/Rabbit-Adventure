using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_idle : MonoBehaviour
{
    public GameObject bird;
    public float birdSpawnTime = 1.5f;
    public GameObject missile;
    float deltaTime = 0;
    float deltaTime1 = 0;
    float birdSpeed = 15;
    Vector3 pos;

    private void Start()
    {
        pos = bird.transform.position;
    }
    void Update()
    {
        float n1 = Random.Range(1, 2f);
        float missileSpawnTime = n1 * 0.7f;
        transform.position += Vector3.left * birdSpeed * Time.deltaTime;
        deltaTime += Time.deltaTime;
        deltaTime1 += Time.deltaTime;
        if(deltaTime > birdSpawnTime)
        {
            deltaTime = 0;
            GameObject bird_obj = Instantiate(bird, pos,Quaternion.identity) as GameObject;
        }
        if(deltaTime1 > missileSpawnTime)
        {
            deltaTime1 = 0;
            GameObject missile_obj = Instantiate(missile, bird.transform.position, Quaternion.identity) as GameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("birdDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
