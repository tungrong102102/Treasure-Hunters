using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_StunState : E_State
{
    private Boss boss;
    public bool isStunOver;
    private float startStunTime;
    public B_StunState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        startStunTime = Time.time;
        isStunOver = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + entityData.stunTime)
        {
            isStunOver = true;
        }
        if (isStunOver)
        {
            stateMachine.ChangeState(boss.idleState);
        }
    }
}
