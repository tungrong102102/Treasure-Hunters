using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected float StartTime;
    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }
    public virtual void DoCheck() { }
    public virtual void Enter()
    {
        DoCheck();
        StartTime = Time.time;
        player.animator.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicsUpdate() { DoCheck(); }


}
