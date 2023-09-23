using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_DeathState : E_State
{
    private Boss boss;
    public B_DeathState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName, Boss boss) : base(entity, stateMachine, entityData, animBoolName)
    {
        this.boss = boss;
    }
    public override void Exit()
    {
        base.Exit();
        boss.gameObject.SetActive(false);
    }
}
