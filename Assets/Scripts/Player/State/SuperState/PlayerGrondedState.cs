using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrondedState : PlayerState
{
    //Check Input
    protected int xInput;
    protected bool JumpInput;
    protected bool AttackInput;
    protected bool throwSwordInput;
    //Check 
    protected bool isGrounded;
    protected bool isCelling;

    //set time 

    public PlayerGrondedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        isGrounded = player.CheckGrounded();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.inputHandler.NorInputX;
        JumpInput = player.inputHandler.JumpInput;
        AttackInput = player.inputHandler.AttackInput;
        throwSwordInput = player.inputHandler.ThrowSwordInput;
        if (player.animFinish)
            if (JumpInput)
            {
                player.inputHandler.UseJumpInput();
                stateMachine.ChangeState(player.jumpState);
            }
            else if (isGrounded)
            {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.moveState);
                }
                else
                {
                    stateMachine.ChangeState(player.idleState);
                }
                if (throwSwordInput && player.playerSword)
                {
                    player.inputHandler.UseThrowSwordInput();
                    stateMachine.ChangeState(player.throwSwordState);
                    player.transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (AttackInput && player.playerSword && player.animFinish)
                {
                    player.inputHandler.UseAttackInput();
                    player.animFinish = false;
                    player.transform.GetChild(1).gameObject.SetActive(true);
                    stateMachine.ChangeState(player.CombatState);
                }
            }
            else
            {
                stateMachine.ChangeState(player.airState);
            }

    }
}
