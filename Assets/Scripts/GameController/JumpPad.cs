using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float bouce = 20f;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Player", true);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Player", false);
        }
    }
}
