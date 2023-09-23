using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToState : MonoBehaviour
{
    public E_MeleeAttackState meleeAttackState;
    public void TriggerAttack()
    {
        meleeAttackState.TriggerAttack();
    }
    public void AnimationFinish()
    {
        meleeAttackState.AttackFinished();
    }
    public void DeadthFinish()
    {
        gameObject.SetActive(false);
    }
}
