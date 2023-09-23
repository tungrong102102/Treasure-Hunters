using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DeadState : E_DeadState
{
    private E_Crabby crabby;
    public C_DeadState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Crabby crabby) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.crabby = crabby;
    }
    public override void Enter()
    {
        base.Enter();
    }
}
