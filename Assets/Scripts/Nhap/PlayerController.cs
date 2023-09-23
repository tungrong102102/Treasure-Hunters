using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    public PlayerInputHandler inputHandler;
    public int FacingDirection;

    [SerializeField]
    public GameObject playerNotSword;
    public GameObject playerSword;

    public Animator animator;
    private SpriteRenderer spr;
    private Rigidbody2D rb;

    [SerializeField]
    private Transform GroundedCheck;

    private int amountToJump;

    //Check Variables
    public bool Grounded;
    private bool CanJump;
    //Check Input
    private bool JumpInput;
    private int xInput;
    public bool Sword;

    //Check Animation
    private bool move;

    private void Awake()
    {
        animator = playerNotSword.GetComponent<Animator>();
        Sword = false;
        FacingDirection = 1;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        amountToJump = 0;
    }
    private void Update()
    {
        CheckInput();
        CheckPlayerDirection();
        CheckCanJump();
        CheckAnimations();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckInput()
    {
        xInput = inputHandler.NorInputX;
        JumpInput = inputHandler.JumpInput;
        if (JumpInput && CanJump)
        {
            inputHandler.UseJumpInput();
            amountToJump++;
            rb.velocity = Vector2.up * playerData.JumpVelocity;
        }
    }
    private void CheckCanJump()
    {
        if (Grounded) amountToJump = 0;
        if (amountToJump < 2)
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
    }
    private void ApplyMovement()
    {
        if (xInput != 0)
        {
            rb.velocity = new Vector2(xInput * playerData.movementSpeed, rb.velocity.y);
        }
    }
    private void CheckPlayerDirection()
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
    public void CheckSurroundings()
    {
        Grounded = CheckGrounded();
    }
    public void CheckAnimations()
    {
        if (Grounded && xInput != 0)
            move = true;
        else
            move = false;
        animator.SetBool("move", move);
        animator.SetBool("grounded", Grounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("Sword", Sword);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Sword = true;

        }
    }
    public bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(GroundedCheck.position, playerData.groundedRadius, playerData.WhatIsGrounded);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundedCheck.position, playerData.groundedRadius);
    }
}
