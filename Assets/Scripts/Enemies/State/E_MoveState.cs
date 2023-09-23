using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_MoveState : E_State
{
    protected bool wallCheck;
    protected bool groundCheck;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    public E_MoveState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocity(entityData.moveSpeed);
    }
    public override void DoChecks()
    {
        base.DoChecks();
        wallCheck = entity.CheckWall();
        groundCheck = entity.CheckGrounded();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
