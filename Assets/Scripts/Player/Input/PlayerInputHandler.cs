using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NorInputX { get; private set; }
    public int NorInputY { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool AttackInput { get; private set; }
    public bool ThrowSwordInput { get; private set; }
    private float InputHoldTime = 0.2f;
    private float JumpInputStartTime;
    private float nextAttack;
    public float attackRate = 2f;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NorInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        NorInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;

    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            JumpInput = true;
            JumpInputStartTime = Time.time;
        }
        else
        {
            JumpInput = false;
        }
    }
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started && Time.time > nextAttack)
        {
            AttackInput = true;
            nextAttack = Time.time + 0.5f;
        }
        else if (context.canceled)
        {
            AttackInput = false;
        }
    }
    public void OnThrowSwordInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ThrowSwordInput = true;
        }
        else if (context.canceled)
        {
            ThrowSwordInput = false;
        }
    }
    public void UseJumpInput() => JumpInput = false;
    public void UseAttackInput() => AttackInput = false;
    public void UseThrowSwordInput() => ThrowSwordInput = false;

    public void CheckJumpInputHoldTime()
    {
        if (Time.time >= JumpInputStartTime + InputHoldTime)
        {
            JumpInput = false;
        }
    }
}
