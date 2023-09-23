using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerDetectedState : E_PlayerDetectedState
{
    private E_Crabby crabby;
    public C_PlayerDetectedState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Crabby crabby) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.crabby = crabby;
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performCloseRangeAction && isAttacking)
        {
            isAttacking = false;
            stateMachine.ChangeState(crabby.attackPlayerState);
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(crabby.runState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(crabby.lookForPlayerState);
        }
        else if (!isGrounded && isWall)
        {
            entity.Flip();
            stateMachine.ChangeState(crabby.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
