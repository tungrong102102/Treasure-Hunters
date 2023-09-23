using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamagebleAndKnockBack
{
    #region State variables
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpStae jumpState { get; private set; }
    public PlayerInAirState airState { get; private set; }
    public PlayerLandState landState { get; private set; }
    public PlayerThrowSwordState throwSwordState { get; private set; }
    public DeathState deathState { get; private set; }
    // public PlayerAttackState attackState { get; private set; }
    public MelleCombatState CombatState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Commponent
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    public HealthBarPlayer healthBarPlayer;
    #endregion

    #region Check variables
    public Transform GroundedCheck;
    private float knockBackTimer;
    public bool playerSword;
    public bool isHurt;
    public bool animFinish;
    public bool deathExit;
    public bool isKnockBack;
    public float KnockBackDuration;

    #endregion

    #region Other variables
    public Transform throwSwordStart;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    public int currentHealth;
    public int maxHealth;
    public Vector3 lastPosition;
    private Vector2 workspace;
    public List<Transform> P_Effect;

    #endregion

    #region Unity Callbacks Functions

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        jumpState = new PlayerJumpStae(this, stateMachine, playerData, "inAir");
        airState = new PlayerInAirState(this, stateMachine, playerData, "inAir");
        deathState = new DeathState(this, stateMachine, playerData, "death");
        throwSwordState = new PlayerThrowSwordState(this, stateMachine, playerData, "throwSword");
        CombatState = new MelleCombatState(this, stateMachine, playerData, "attack");
    }
    protected void Start()
    {
        deathExit = false;
        currentHealth = maxHealth;
        healthBarPlayer.SetMaxHealth(currentHealth);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inputHandler = GetComponent<PlayerInputHandler>();
        FacingDirection = 1;
        stateMachine.Initialized(idleState);
        transform.GetChild(1).gameObject.SetActive(false);
        animFinish = true;
        playerSword = false;
        transform.position = lastPosition;
    }

    protected void Update()
    {
        CurrentVelocity = rb.velocity;
        stateMachine.currentState.LogicUpdate();
        AnimationController();
        if (knockBackTimer > 0)
        {
            isKnockBack = true;
            knockBackTimer -= Time.deltaTime;
        }
        else
        {
            isKnockBack = false;
        }
    }
    protected void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        if (!isKnockBack)
        {
            workspace = new Vector2(velocity, CurrentVelocity.y);
            rb.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }
    public void SetVelocityY(float velocity)
    {
        if (!isKnockBack)
        {
            workspace = new Vector2(CurrentVelocity.x, velocity);
            rb.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }
    public void SetLastPosition(Vector3 position)
    {
        lastPosition = position;
    }
    #endregion

    #region Check Functions
    public bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(GroundedCheck.position, playerData.groundedRadius, playerData.WhatIsGrounded);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Functions
    public void Die()
    {
        animator.SetTrigger("Death");
    }
    public void LoadPosition()
    {
        transform.position = lastPosition;
        currentHealth = 100;
        healthBarPlayer.SetMaxHealth(currentHealth);
        animFinish = true;
    }
    public void OnHit(int damage)
    {
        isHurt = true;
        currentHealth -= damage;
        healthBarPlayer.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        if (currentHealth <= 10)
        {
            Die();
        }
    }

    public void KnockBack(Vector2 pos, float knockbackForce)
    {
        Vector2 dir = ((Vector2)transform.position - pos).normalized;
        rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
        knockBackTimer = KnockBackDuration;
    }
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, -180f, 0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundedCheck.position, playerData.groundedRadius);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword")
        {
            playerSword = true;
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region Animation Functions
    public void ThrowSword()
    {
        Instantiate(playerData.throwObject, throwSwordStart.position, transform.rotation);
        playerSword = false;
    }
    public void animationFinish()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        animFinish = true;

    }
    public void E_Attack()
    {
        if (CombatState.attackIndex - 1 == 1)
        {
            Instantiate(playerData.Effect[0], P_Effect[0].position, transform.rotation);
        }
        else if (CombatState.attackIndex - 1 == 2)
        {
            Instantiate(playerData.Effect[1], P_Effect[1].position, transform.rotation);
        }
        else
        {
            Instantiate(playerData.Effect[2], P_Effect[2].position, transform.rotation);
        }
    }
    public void AnimationController()
    {
        if (playerSword == false)
        {
            animator.SetLayerWeight(1, 0);
        }
        else
            animator.SetLayerWeight(1, 1);
    }
    public void AnimationStart() => animFinish = false;
    public void HurtFinish() => isHurt = false;
    #endregion
}
