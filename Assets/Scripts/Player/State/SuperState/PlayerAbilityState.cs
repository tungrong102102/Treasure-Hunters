using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    protected bool isGrounded;
    protected bool attacInput;
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckGrounded();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
            if (isGrounded)
                stateMachine.ChangeState(player.idleState);
            else
            {
                stateMachine.ChangeState(player.airState);
            }
        }
    }
}
