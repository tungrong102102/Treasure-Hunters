using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerDetectedState : E_State
{
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isAttacking;
    protected bool isGrounded;
    protected bool isWall;
    public E_PlayerDetectedState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {

    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isGrounded = entity.CheckGrounded();
        isWall = entity.CheckWall();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > startTime + entityData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
        if (Time.time >= entityData.attackDelay + startTime)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
    public override void Enter()
    {
        GameObject.Instantiate(entityData.Dialogue_2, entity.postionDialogue.position, entity.transform.rotation);
        base.Enter();
        performLongRangeAction = false;
        entity.SetVelocity(0f);
        isAttacking = false;
    }
}
