using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_State
{
    protected E_StateMachine stateMachine;
    protected Entity entity;
    protected string animBoolName;
    public float startTime { get; protected set; }
    protected D_Entity entityData;

    public E_State(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.entityData = entityData;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        entity.animator.SetBool(animBoolName, true);
        Debug.Log(animBoolName);
    }
    public virtual void Exit()
    {
        entity.animator.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {
        DoChecks();
    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }
}
