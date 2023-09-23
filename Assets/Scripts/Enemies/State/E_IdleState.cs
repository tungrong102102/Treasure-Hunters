using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_IdleState : E_State
{
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected float idleTime;
    protected bool isPlayerInMaxAgroRange;
    protected bool isPlayerInMinAgroRange;
    public E_IdleState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }
    public override void Exit()
    {
        base.Exit();
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }
    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }
    public void SetRandomIdleTime()
    {
        idleTime = Random.Range(entityData.minIdleTime, entityData.maxIdleTime);
    }
}
