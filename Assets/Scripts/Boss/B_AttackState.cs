using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_AttackState : E_MeleeAttackState
{
    private bool checkAttack;
    private bool CheckWall;
    private bool checkFlipAttack;
    private bool stun;
    public bool animHurt;
    private float startStunTime;
    private Boss boss;
    public B_AttackState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        base.Enter();
        startStunTime = entityData.stundurationtime;
        animHurt = false;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        checkAttack = boss.CheckAttack();
        checkFlipAttack = boss.CheckAttackFlip();
        CheckWall = entity.CheckWall();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocity(entityData.runSpeed);
        if (CheckWall || checkFlipAttack)
        {
            boss.Flip();
        }
        else if (!checkAttack)
            stateMachine.ChangeState(boss.idleState);
        else if (Time.time >= startTime + entityData.stundurationtime)
        {
            animHurt = true;
            stateMachine.ChangeState(boss.stunState);
        }
    }
}
