using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_missile : MonoBehaviour
{
    public float missileSpawnTime = 1.0f;
    public GameObject enemy;
    public GameObject missile;
    GameObject obj;
    float deltaTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime > missileSpawnTime)
        {
            deltaTime = 0.0f;
            obj = Instantiate(missile,new Vector3(enemy.transform.position.x, enemy.transform.position.y,35), Quaternion.identity) as GameObject;
        }
    }
}
