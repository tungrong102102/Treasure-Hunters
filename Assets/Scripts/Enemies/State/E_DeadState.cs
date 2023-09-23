using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DeadState : E_State
{
    public E_DeadState(Entity entity, E_StateMachine stateMachine, D_Entity entityData, string animBoolName) : base(entity, stateMachine, entityData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        entity.animator.SetTrigger("Death");
        GameObject.Instantiate(entityData.Dialogue_3, entity.postionDialogue.position, entity.transform.rotation);
        GameObject.Destroy(entity.gameObject, 5f);
    }
}
