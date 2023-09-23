using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleCombatState : PlayerAbilityState
{
    public float nextTime;
    public float attackRate = 0.2f;
    public int attackIndex = 1;
    public float attackTime = 1f;
    public float attackStartTime;
    public MelleCombatState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        isAbilityDone = true;

    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ResetAttack();
        if (isGrounded)
        {
            if (attackIndex == 1)
            {
                player.animator.SetTrigger("attack" + attackIndex);
                attackStartTime = Time.time;
                attackIndex++;
            }
            else if (attackIndex == 2)
            {
                player.animator.SetTrigger("attack" + attackIndex);
                attackStartTime = Time.time;
                attackIndex++;
            }
            else if (attackIndex == 3)
            {
                player.animator.SetTrigger("attack" + attackIndex);
                attackStartTime = Time.time;
                attackIndex++;
                attackIndex = 1;
            }
        }
        else
        {
            player.animator.SetTrigger("airAttack");
        }
    }
    public void ResetAttack()
    {
        if (Time.time >= attackStartTime + attackTime)
        {
            attackIndex = 1;
        }
    }
}
