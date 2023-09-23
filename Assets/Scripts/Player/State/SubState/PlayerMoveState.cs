using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGrondedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(xInput * playerData.movementSpeed);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.CheckIfShouldFlip(xInput);

        if (xInput == 0f && !AttackInput)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
