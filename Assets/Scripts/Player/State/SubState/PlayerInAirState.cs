using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //check Input
    private bool jumpInputStop;
    private int xInput;
    private bool isGrounded;
    private bool isJumping;
    private bool attacInput;
    private bool throwSwordInput;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }
    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckGrounded();
    }
    public override void LogicUpdate()
    {

        base.LogicUpdate();


        xInput = player.inputHandler.NorInputX;
        attacInput = player.inputHandler.AttackInput;
        throwSwordInput = player.inputHandler.ThrowSwordInput;
        if (player.animFinish)
            if (isGrounded)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                if (player.playerSword)
                {
                    if (attacInput)
                    {
                        player.inputHandler.UseAttackInput();
                        player.animFinish = false;
                        player.transform.GetChild(1).gameObject.SetActive(true);
                        stateMachine.ChangeState(player.CombatState);
                    }
                    if (throwSwordInput)
                    {
                        player.inputHandler.UseThrowSwordInput();
                        player.animFinish = false;
                        stateMachine.ChangeState(player.throwSwordState);
                    }
                }

                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(xInput * playerData.movementSpeed);
                player.animator.SetFloat("yVelocity", player.CurrentVelocity.normalized.y);
            }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
