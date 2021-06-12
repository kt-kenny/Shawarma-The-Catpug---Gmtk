using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    //private Animator anim;
    private Transform trans;

    
    // States
    private bool facingRight = true;//player starts facing right
    public bool isGrounded = false;
    private bool isRunning = false; //moving horizontal and is grounded
    private bool isMovingHorizontal = false;
    private bool isMovingUp = false;
    private bool isAlive = true;

    public bool isDog = false;



    //movement variables
    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private float acceleration = 0.01f;
    [SerializeField] private float decceleration = 0.002f;
    private float speed;
    private float moveInput;
    [SerializeField] private float jumpForce = 5; // jumpvariables; code brrowed from Boards to bits
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    private int airJumps = 0;
    [SerializeField] private int maxAirJumps = 1;
    


    //Light Variables
    public Light2D light;
    public float dogOuterRadius = 0.7f;
    public float dogInnnerRadius = 0.10f;
    public float catOuterRadius = 15f;
    public float catInnnerRadius = 8f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }


    // Limit Switching
    [SerializeField] private int numSwitches = 6;






    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            Move();
            CheckAndFlip();
            CheckSwitch();
            UpdateVision(); // Cat sees platforms, dog sniff traps
        }
    }

    private void Move() {
        HorizMovement();
        //Jumping
        JumpLogic();
    }

    private void HorizMovement() {
        moveInput = Input.GetAxisRaw("Horizontal"); //float of -1 or 1 that tells direction// moving horizontal

        if (moveInput != 0) {//accelerate 
            speed = rb.velocity.x + maxSpeed * acceleration * moveInput;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //isMovingHorizontal = true;// update state
        }
        else if (Mathf.Abs(rb.velocity.x) > 0.5) { //if not holding move button deccelerate //idling
            if (rb.velocity.x > 0) {
                speed = rb.velocity.x - maxSpeed * decceleration;
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (rb.velocity.x < 0) {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            else if (rb.velocity.x < 0) {
                speed = rb.velocity.x + maxSpeed * decceleration;
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (rb.velocity.x > 0) {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            //isMovingHorizontal = false;// update state

        }
        //Setting max speed
        if (rb.velocity.x > maxSpeed && moveInput > 0) {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed && moveInput < 0) {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }


    }

    private void JumpLogic() {
        if (isGrounded) airJumps = 0;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        else if (!isGrounded && Input.GetKeyDown(KeyCode.Space) && airJumps < maxAirJumps) {
            //print("hello");
            airJumps += 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //anim.SetTrigger("double jump"); // animation trigger here cuz dunno where else to put it
        }
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void CheckAndFlip() {
        if (facingRight && rb.velocity.x < -0.01) {
            facingRight = false;
            trans.RotateAround(transform.position, transform.up, 180);//rotate player around y axis 180 to flip
        }
        else if (!facingRight && rb.velocity.x > 0.01) {//use 0.5 instead of 0 to provide lenience
            facingRight = true;
            trans.RotateAround(transform.position, transform.up, 180);
        }
    }

    private void CheckSwitch() {
        if (Input.GetButtonDown("Fire1") && numSwitches > 0){ // pressed mouse click/ switch chracter
            numSwitches -= 1;

            //Debug.Log(transform.childCount); 
            // Dog is first child at index 0 ; Cat is index 1
            if (isDog) {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false; // deactivate dog sprite
                transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true; // Activate Cat
                isDog = false;
            }
            else {
                isDog = true;
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true; //activate dpg sprite
                transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false; // deactivate Cat

            }


        }
    }

    private void UpdateVision() {
        Debug.Log("Hello");
        Debug.Log(light.pointLightOuterRadius);
        if (!isDog) { // is cat
            //print("isCat");
            light.pointLightOuterRadius = catOuterRadius;
            light.pointLightInnerRadius = catInnnerRadius;
            
        }
        else { //is dog
            //print("isDog");
            light.pointLightOuterRadius = dogOuterRadius;
            light.pointLightInnerRadius = dogInnnerRadius;
        }
        
    }

    private void Die() {
        isAlive = false;
        //anim.SetTrigger("Dead");
        StartCoroutine(DyingCoroutine());
        
    }

    private IEnumerator DyingCoroutine() { // Wait 2 seconds then restart scene, or go main menu
        yield return new WaitForSeconds(2);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }


    public void ExplodePlayer() {
        rb.velocity = rb.velocity * -3;
        Die();
    }


}
