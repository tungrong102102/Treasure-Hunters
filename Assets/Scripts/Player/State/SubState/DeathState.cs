using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerState
{
    public bool isGrounded;
    public DeathState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckGrounded();
    }
    public override void Enter()
    {
        base.Enter();
        player.animator.SetTrigger("Death");
        player.SetVelocityX(0f);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isGrounded)
            stateMachine.ChangeState(player.idleState);
    }
}
