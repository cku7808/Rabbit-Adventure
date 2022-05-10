using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airPlane : MonoBehaviour
{
    Vector3 target = new Vector3(240, 15.4f, 36.8f);
    playerMove player;
    private void Start()
    {
        player = GameObject.Find("player2").GetComponent<playerMove>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            player.moveSpeed = 20;
            transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            player.moveSpeed = 15;
        }
    }
}
