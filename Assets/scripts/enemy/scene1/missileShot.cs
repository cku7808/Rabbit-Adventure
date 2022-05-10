using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileShot : MonoBehaviour
{
    public float shotSpeed = 10;
    public static int version = 0;
    public int state;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("missileDestroy"))
        {
            Destroy(gameObject);
        }
    }
    private void Shoot()
    {
        if (state == version)
        {
            transform.position += shotSpeed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += shotSpeed * Vector3.right * Time.deltaTime;
        }
    }
}
