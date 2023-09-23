using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_MeleeAttackState : E_State
{
    protected bool isPlayerInMinArgo;
    public bool animFinished;
    protected float attackSpeed = 1f;
    public E_MeleeAttackState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinArgo = entity.CheckPlayerInMinAgroRange();
    }
    public override void Enter()
    {
        base.Enter();
        entity.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Instantiate(entityData.prefabEffect, entity.EffectAttack.position, entity.transform.rotation);
        entity.ats.meleeAttackState = this;
        animFinished = false;
        entity.SetVelocity(0f);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // entity.SetVelocity(0f);


    }
    public override void Exit()
    {
        base.Exit();
        entity.transform.GetChild(0).gameObject.SetActive(false);
    }
    public virtual void TriggerAttack()
    {

    }
    public virtual void AttackFinished()
    {
        animFinished = true;

    }
}
