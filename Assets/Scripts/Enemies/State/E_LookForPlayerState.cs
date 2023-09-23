using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_LookForPlayerState : E_State
{
    protected bool turnImmediately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int amountOfTurnsDone;
    public E_LookForPlayerState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {

    }
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
    public override void Enter()
    {
        base.Enter();
        GameObject.Instantiate(entityData.Dialogue_1, entity.postionDialogue.position, entity.transform.rotation);
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

        entity.SetVelocity(0f);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (turnImmediately)
        {
            entity.SetVelocity(0f);
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediately = false;
        }
        else if (Time.time >= lastTurnTime + entityData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if (amountOfTurnsDone >= entityData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }
        if (Time.time >= lastTurnTime + entityData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsDone = true;
        }
    }

    public void SetTurnImmediately(bool Flip)
    {
        turnImmediately = Flip;
    }
}
