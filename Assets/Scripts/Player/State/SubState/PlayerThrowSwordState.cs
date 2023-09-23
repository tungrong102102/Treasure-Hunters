using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowSwordState : PlayerAbilityState
{
    public PlayerThrowSwordState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        isAbilityDone = true;
        player.SetVelocityX(0f);
        player.animator.SetTrigger("throwSword");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        if (player.playerSword == false)
        {
            player.AnimationController();
            stateMachine.ChangeState(player.idleState);
        }
    }
    public bool CanThrowSword()
    {
        if (player.playerSword == false)
        {
            return false;
        }
        else
            return true;
    }
}
