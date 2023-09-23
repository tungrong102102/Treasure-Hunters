using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newD_Entiy", menuName = "newD_Entiy")]
public class D_Entity : ScriptableObject
{
    [Header("====BOSS=====")]
    [Header("stun State")]
    public float stunTime = 3f;
    public float stundurationtime = 10f;

    [Header("attack State")]
    public float damage;
    public float attackStun;
    [Header("Check variables")]
    public float groundCheckDistance = 0.3f;
    public float wallCheckDistance = 0.5f;

    public LayerMask WhatIsGrounded;

    [Header("Idle State")]
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;

    [Header("Move State")]
    public float moveSpeed = 3f;

    [Header("Run Staet")]
    public float runSpeed = 6f;
    public float runTime = 1.5f;

    [Header("Player detected State")]
    public float longRangeActionTime = 1.5f;

    [Header("Look For Player State")]
    public float timeBetweenTurns = 0.75f;
    public int amountOfTurns = 2;

    [Header("Check Player")]
    public float minAgroDistance = 7f;
    public float maxAgroDistance = 8f;
    public LayerMask WhatIsPlayer;

    [Header("Attack State")]
    public float closeRangeActionDistance = 1f;
    public float attackDelay = 1f;
    public GameObject prefabEffect;

    [Header("Shoot State")]
    public GameObject bullet;
    public float shootTime = 1.5f;

    [Header("Dialogue")]
    public GameObject Dialogue_1;
    public GameObject Dialogue_2;
    public GameObject Dialogue_3;



}
