using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_ShootState : E_ShootState
{
    private E_Connon connon;
    public Co_ShootState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Connon connon) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.connon = connon;
    }
    public override void Enter()
    {
        base.Enter();
        connon.animFinished = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (connon.animFinished)
            stateMachine.ChangeState(connon.idleState);
    }
    public override void InstanceBullet()
    {
        base.InstanceBullet();
    }
}
