using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperPlane : MonoBehaviour
{
    // Start is called before the first frame update
    public playerMove player;
    float speed = 13.0f;
    Vector3 dir = Vector3.right;

    void Start()
    {
        player = GameObject.Find("player2").GetComponent<playerMove>();
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("planeManager1"))
        {
            transform.localScale = new Vector3(12, 10, 1);
            dir = Vector3.right;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("planeManager2"))
        {
            transform.localScale = new Vector3(-12, 10, 1);
            dir = Vector3.left;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
            player.rigidbody.gravityScale = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            player.rigidbody.gravityScale = 4;
        }
    }
}
