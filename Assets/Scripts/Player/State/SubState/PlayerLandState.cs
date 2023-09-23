using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGrondedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
        else
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
