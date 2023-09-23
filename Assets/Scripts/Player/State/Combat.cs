using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        transform.Find("Attack").gameObject.SetActive(false);
    }
    public void Enter()
    {
        transform.Find("Attack").gameObject.SetActive(true);

        animator.SetBool("Attack", true);
    }
    public void Exit()
    {
        transform.Find("Attack").gameObject.SetActive(false);

        animator.SetBool("Attack", false);
    }
}
