using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RunState : E_State
{

    protected bool isGrounded;
    protected bool isWall;
    protected bool isTimeOverRun;
    protected bool isPlayerInMinAgroRange;
    protected bool performCloseRangeAction;
    protected bool isAttacking;
    public E_RunState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(entityData.runSpeed);
        isTimeOverRun = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocity(entityData.runSpeed);

        if (Time.time >= startTime + entityData.runTime)
        {
            isTimeOverRun = true;
        }
        if (Time.time >= entityData.attackDelay + startTime)
        {
            isAttacking = true;
        }
    }
    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = entity.CheckGrounded();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

}
