using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SummonState : E_State
{
    private Boss boss;
    public B_SummonState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        base.Enter();
        boss.SummonRandom();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMachine.ChangeState(boss.idleState);
    }
}
