using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{
    public B_IdleState idleState { get; private set; }
    public B_AttackState attackState { get; private set; }
    public B_MoveState moveState { get; private set; }
    public B_StunState stunState { get; private set; }
    public B_DeathState deathState { get; private set; }
    public B_SummonState summonState { get; private set; }
    public List<GameObject> enemies;
    public Transform pos1;
    public Transform pos2;
    public Transform checkflipattack;
    public override void Start()
    {
        base.Start();

        idleState = new B_IdleState(this, stateMachine, entityData, "idle", this);
        attackState = new B_AttackState(this, stateMachine, entityData, "attack", this);
        moveState = new B_MoveState(this, stateMachine, entityData, "move", this);
        stunState = new B_StunState(this, stateMachine, entityData, "stun", this);
        deathState = new B_DeathState(this, stateMachine, entityData, "dead", this);
        summonState = new B_SummonState(this, stateMachine, entityData, "summon", this);

        currentHealth = maxHealth;
        stateMachine.Initialized(idleState);
    }
    public bool CheckAttack()
    {
        return playerCheck.GetComponent<CheckPlayer>().isAttack;
    }
    public bool CheckAttackFlip()
    {
        return Physics2D.Raycast(checkflipattack.position, transform.right * -1, entityData.minAgroDistance, entityData.WhatIsPlayer);
    }
    public bool CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length >= 3)
            return true;
        return false;
    }
    public void SummonRandom()
    {
        Instantiate(enemies[(int)Random.Range(0, 2)], pos1.position, transform.rotation);
        Instantiate(enemies[(int)Random.Range(0, 2)], pos2.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ThrowSword")
        {
            stateMachine.ChangeState(stunState);
        }
    }
    public void DeadState()
    {
        this.gameObject.SetActive(false);
    }

    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("dead");
            stateMachine.ChangeState(deathState);
        }
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(checkflipattack.position, checkflipattack.position + (Vector3)(transform.right * entityData.minAgroDistance));
    }
}
