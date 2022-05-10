using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderManager : MonoBehaviour
{
    public float missileSpawnTime = 1.0f;
    public GameObject cloud;
    public GameObject thunder;
    GameObject obj;
    float deltaTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > missileSpawnTime)
        {
            deltaTime = 0.0f;
            obj = Instantiate(thunder, new Vector3(cloud.transform.position.x, cloud.transform.position.y, 95), Quaternion.identity) as GameObject;
        }
    }
}
