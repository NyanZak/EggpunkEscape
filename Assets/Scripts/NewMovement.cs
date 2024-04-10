using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{

    private bool facingDirection = true;
    private bool isRunning;
    private bool isGrounded;
    private bool canJump;
    private bool isThrowing;
    private bool canThrow;
    public AudioSource SFX;
    public AudioClip Jumping;
    public AudioClip Throwing;

    private float movementInputDirection;
    public float movementSpeed = 10.0f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public float jumpHeightMultiplier = 0.5f;

    public LayerMask isGround;
	
	public FinalCountDown Countdown;

    private Animator anim;

    public Transform groundCheck;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }


    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }


    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            canThrow = true;
            canJump = true;
        }
        else if (!isGrounded)
        {
            canThrow = false;
            canJump = false;
        }
    }


    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
    }


    private void CheckMovementDirection()
    {
        if(facingDirection && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!facingDirection && movementInputDirection > 0)
        {
            Flip();
        }

        if (rb.velocity.x != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }


    private void UpdateAnimations()
    {
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isThrowing", isThrowing);
    }


    private void Flip()
    {
        facingDirection = !facingDirection;
        transform.Rotate(0, 180, 0);
    }


    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpHeightMultiplier);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SFX.PlayOneShot(Jumping);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canThrow)
        {
            SFX.PlayOneShot(Throwing);
            isThrowing = true;
        }

        else if (!canThrow || Input.GetKeyUp(KeyCode.Mouse0))
        {
            isThrowing = false;
        }
    }


    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PuzzleTrigger2" && !Countdown.hasAddedEggs1)
        {
            Countdown.PuzzleTimer1 = false;
            Countdown.PuzzleTimer3 = false;
            Countdown.PuzzleTimer2 = true;
            Countdown.hasAddedEggs1 = true;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
            Countdown.currentEggCount += 1f - 0.5f;
        }

        if (col.gameObject.name == "PuzzleTrigger3")
        {
            Countdown.PuzzleTimer1 = false;
            Countdown.PuzzleTimer2 = false;
            Countdown.PuzzleTimer3 = true;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
