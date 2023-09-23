using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_IdleState : E_IdleState
{
    private E_Connon connon;
    private bool performCloseRangeAction;
    protected bool isShootting;
    private float nextFire;
    public Co_IdleState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, E_Connon connon) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.connon = connon;
    }
    public override void DoChecks()
    {
        base.DoChecks();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performCloseRangeAction && Time.time >= nextFire)
        {
            nextFire = Time.time + entityData.shootTime;
            stateMachine.ChangeState(connon.shootState);
        }
    }



}

