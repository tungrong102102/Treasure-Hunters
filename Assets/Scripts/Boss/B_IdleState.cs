using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_IdleState : E_IdleState
{
    private Boss boss;
    private bool checkAttack;

    public B_IdleState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        checkAttack = boss.CheckAttack();

    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (checkAttack)
            stateMachine.ChangeState(boss.attackState);
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(boss.moveState);
        }

    }
}
