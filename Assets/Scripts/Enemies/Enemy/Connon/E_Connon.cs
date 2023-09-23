using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Connon : Entity
{
    public Co_IdleState idleState { get; private set; }
    public Co_ShootState shootState { get; private set; }
    public bool animFinished;
    public GameObject Death;
    public Transform DeathTransform;
    public override void Start()
    {
        base.Start();
        animFinished = false;
        idleState = new Co_IdleState(this, stateMachine, entityData, "idle", this);
        shootState = new Co_ShootState(this, stateMachine, entityData, "shooting", this);
        stateMachine.Initialized(idleState);
    }
    public void shootingFinished()
    {
        animFinished = true;
    }
    public void InstanceBullet()
    {
        Instantiate(entityData.bullet, postionShoot.position, transform.rotation);
    }
    public void InstanceEffectAndBullet()
    {
        Instantiate(entityData.prefabEffect, EffectAttack.position, transform.rotation);
        Instantiate(entityData.bullet, postionShoot.position, transform.rotation);
    }
    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
    public void InstantiateDeath()
    {
        Destroy(gameObject);
        Instantiate(Death, DeathTransform.position, transform.rotation);
    }
}
