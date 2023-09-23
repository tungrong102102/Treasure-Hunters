using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AttackPlayer : E_MeleeAttackState
{
    private E_Crabby crabby;
    public C_AttackPlayer(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Crabby crabby) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.crabby = crabby;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinished)
        {
            if (isPlayerInMinArgo)
            {
                stateMachine.ChangeState(crabby.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(crabby.lookForPlayerState);
            }
        }
    }

    public override void AttackFinished()
    {
        base.AttackFinished();
    }
}
