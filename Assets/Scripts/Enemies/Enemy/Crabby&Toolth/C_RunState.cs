using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RunState : E_RunState
{
    private E_Crabby crabby;
    public C_RunState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Crabby crabby) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.crabby = crabby;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performCloseRangeAction && isAttacking)
        {
            isAttacking = false;
            stateMachine.ChangeState(crabby.attackPlayerState);
        }
        else if (!isGrounded || isWall)
        {
            stateMachine.ChangeState(crabby.lookForPlayerState);
        }
        else if (isTimeOverRun)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(crabby.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(crabby.idleState);
            }
        }
    }

}
