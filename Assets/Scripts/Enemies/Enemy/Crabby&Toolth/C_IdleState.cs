using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_IdleState : E_IdleState
{
    private E_Crabby crabby;
    public C_IdleState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Crabby crabby) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.crabby = crabby;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(crabby.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(crabby.moveState);
        }
    }
}
