using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_missile : MonoBehaviour
{
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("gameOver"))
        {
            Destroy(gameObject);
        }
    }
}
