using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ShootState : E_State
{
    protected bool preformCloseRangeAction;
    protected bool isShootting;
    protected float shootTime = 2f;
    protected float nextFire;
    public E_ShootState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void DoChecks()
    {
        base.DoChecks();
        preformCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + shootTime;
            isShootting = true;
        }
        else
        {
            isShootting = false;
        }
    }
    public virtual void InstanceBullet()
    {
        GameObject.Instantiate(entityData.bullet, entity.postionShoot.position, entity.transform.rotation);
    }
}
