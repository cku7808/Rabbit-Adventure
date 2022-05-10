using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpPower = 10;
    public float superJumpPower = 20;
    bool isGround;
    public float currentTime;
    public Rigidbody2D rigidbody;
    Animator animator;
    public float knockBackPower = 20000;
    SpriteRenderer sprite;
    AudioSource audioSource;
    public AudioClip jump;
    public AudioClip collisionSound;
    public AudioClip superJump;
    public AudioClip gameOver;

    public static int stageLevel = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Camera.main.transform.position = transform.position - Vector3.forward;
    }
    private void Move()
    {
        Vector3 moveVector = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVector = Vector3.right;
            transform.localScale = new Vector3(20, 20, 20);
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVector = Vector3.left;
            transform.localScale = new Vector3(-20, 20, 20);
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isMoving", false);
        }

        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.isGround == true)
            {
                audioSource.PlayOneShot(jump);
                rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                animator.SetTrigger("jump");
                animator.SetBool("isJumping", true);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            this.isGround = true;
            animator.SetBool("isJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            this.isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("missile"))
        {
            audioSource.PlayOneShot(collisionSound);
            Destroy(collision.gameObject);

            if(collision.gameObject.transform.position.x < transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + knockBackPower, transform.position.y + 1, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - knockBackPower, transform.position.y + 1, transform.position.z);
            }
            
            ChangeAlpha(0.7f);
            Invoke("ReturnAlpha", 0.5f);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("gameOver"))
        {
            currentTime = Mathf.Round(timer.time);
            audioSource.PlayOneShot(gameOver);
            SceneManager.LoadScene("GameOver");
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("superJump"))
        {
            audioSource.PlayOneShot(superJump);
            rigidbody.AddForce(Vector2.up * superJumpPower, ForceMode2D.Impulse);
        }
    }
    private void ChangeAlpha(float num)
    {
        Color color = sprite.color;
        color.a = num;
        sprite.color = color;
    }
    private void ReturnAlpha()
    {
        Color color = sprite.color;
        color.a = 1;
        sprite.color = color;
    }
}
