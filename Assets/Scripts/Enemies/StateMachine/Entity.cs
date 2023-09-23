using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamagebleAndKnockBack
{
    public E_StateMachine stateMachine;
    public D_Entity entityData;

    #region  Componemt variables
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public AnimationToState ats { get; private set; }
    public HealthBarPlayer healthBarEnemy;
    #endregion

    #region Check variables
    [SerializeField]
    private Transform groundedCheck;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    protected Transform playerCheck;
    public bool isAttack;
    #endregion

    #region  Other variables
    private int FacingDirection;
    private float knockBackTimer;
    private bool isKnockBack;
    protected int currentHealth;
    public float KnockBackDuration;
    public int maxHealth;
    private Vector2 velocityWorkSpace;
    public Transform postionDialogue;
    public Transform postionShoot;
    public Transform EffectAttack;

    #endregion
    #region Unity CallBack
    public virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ats = GetComponent<AnimationToState>();
        FacingDirection = 1;
        currentHealth = maxHealth;
        healthBarEnemy.SetMaxHealth(maxHealth);
        stateMachine = new E_StateMachine();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
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
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions
    public bool CheckGrounded()
    {
        return Physics2D.Raycast(groundedCheck.position, Vector2.down, entityData.groundCheckDistance, entityData.WhatIsGrounded);
    }
    public bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, transform.right, entityData.wallCheckDistance, entityData.WhatIsGrounded);
    }
    public bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.WhatIsPlayer);
    }
    public bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.WhatIsPlayer);
    }
    public bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.WhatIsPlayer);
    }
    #endregion
    public virtual void SetVelocity(float speed)
    {
        velocityWorkSpace = new Vector2(speed * FacingDirection, rb.velocity.y);
        rb.velocity = velocityWorkSpace;
    }
    public virtual void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0);
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundedCheck.position, groundedCheck.position + (Vector3)(Vector2.down * entityData.groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * entityData.wallCheckDistance));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(transform.right * entityData.closeRangeActionDistance));
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
    }

    public virtual void OnHit(int damage)
    {
        currentHealth -= damage;
        healthBarEnemy.SetHealth(currentHealth);
        animator.SetBool("Hurt", true);
    }
    public virtual void KnockBack(Vector2 pos, float knockbackForce)
    {
        Vector2 dir = ((Vector2)transform.position - pos).normalized;
        rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
        knockBackTimer = KnockBackDuration;
    }
}
