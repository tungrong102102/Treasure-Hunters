using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Crabby : Entity
{
    public C_IdleState idleState { get; private set; }
    public C_MoveState moveState { get; private set; }
    public C_PlayerDetectedState playerDetectedState { get; private set; }
    public C_RunState runState { get; private set; }
    public C_LookForPlayer lookForPlayerState { get; private set; }
    public C_AttackPlayer attackPlayerState { get; private set; }
    public C_DeadState deathState { get; private set; }
    public override void Start()
    {
        base.Start();
        idleState = new C_IdleState(this, stateMachine, entityData, "idle", this);
        moveState = new C_MoveState(this, stateMachine, entityData, "move", this);
        playerDetectedState = new C_PlayerDetectedState(this, stateMachine, entityData, "playerDetected", this);
        runState = new C_RunState(this, stateMachine, entityData, "run", this);
        lookForPlayerState = new C_LookForPlayer(this, stateMachine, entityData, "lookForPlayer", this);
        attackPlayerState = new C_AttackPlayer(this, stateMachine, entityData, "attack", this);
        deathState = new C_DeadState(this, stateMachine, entityData, "death", this);
        stateMachine.Initialized(moveState);
    }
    public override void Update()
    {
        base.Update();
    }
    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (currentHealth <= 0)
        {
            stateMachine.ChangeState(deathState);
        }
    }
}
