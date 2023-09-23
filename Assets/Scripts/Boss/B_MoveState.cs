using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_MoveState : E_MoveState
{
    private Boss boss;
    private bool wallcheck;
    private bool checkAttack;
    private bool CheckSummonEnemies;
    public B_MoveState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        wallCheck = entity.CheckWall();
        checkAttack = boss.CheckAttack();
        CheckSummonEnemies = boss.CheckEnemies();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocity(entityData.moveSpeed);
        if (wallCheck)
        {
            boss.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(boss.idleState);
        }
        else if (checkAttack)
        {
            stateMachine.ChangeState(boss.attackState);
        }
        else if (!CheckSummonEnemies)
        {
            stateMachine.ChangeState(boss.summonState);
        }
    }
}
