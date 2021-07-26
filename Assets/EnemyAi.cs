using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float enemyWalkSpeed = 5f;
    public float enemyWalkRange = 5f;
    private Vector2 origPos;
    private bool facingRight = true;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        origPos = transform.position;
        rb.velocity = Vector2.right * enemyWalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        FlipDirection();
        if(Mathf.Abs(rb.velocity.x) > 0) { anim.SetBool("isWalking",true); }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            if (collision.transform.GetComponent<PlayerController>().isAlive) {
                Vector2 playerVel = collision.transform.GetComponent<Rigidbody2D>().velocity;
                collision.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(playerVel.x, 6);
                collision.transform.GetComponent<PlayerController>().Die();
            }
            
        }
    }


    private void FlipDirection() {
        if (Mathf.Abs(transform.position.x - origPos.x) > enemyWalkRange) {
            TurnAround();
        }
    }


    private void FaceRightWay() {
        if (facingRight && rb.velocity.x < 0) {
            Flip();
            facingRight = false;
        }
        else if (!facingRight && rb.velocity.x > 0) {
            Flip();
            facingRight = true;
        }

    }


    public void TurnAround() {
        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        FaceRightWay();
        origPos = transform.position;
    }


    void Flip() {
        transform.RotateAround(transform.position, transform.up, 180);
    }


}
