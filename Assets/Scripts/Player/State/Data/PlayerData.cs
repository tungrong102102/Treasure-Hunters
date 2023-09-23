using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{

    [Header("Move State")]
    public float movementSpeed = 10f;

    [Header("Jump State")]
    public float JumpVelocity = 15f;
    public int amountToJump = 2;

    [Header("In Air State")]
    public float JumpHeightMultiple = 0.2f;

    [Header("throw State")]
    public GameObject throwObject;
    public float addForce = 4.5f;
    [Header("Check variables")]
    public float groundedRadius = 0.2f;
    public LayerMask WhatIsGrounded;
    [Header("attack State")]
    public List<GameObject> Effect;
}
