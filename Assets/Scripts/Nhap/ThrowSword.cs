using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSword : MonoBehaviour
{
    public float throwSwordSpeed = 4.5f;
    public Animator animator { get; private set; }
    public BoxCollider2D boxCollider2D { get; private set; }
    public Rigidbody2D rd { get; private set; }

    public Vector2 CurrentPosition;
    public Vector2 KnockBack;
    public Player PC;
    private int direction;
    public int damage = 50;
    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rd = GetComponent<Rigidbody2D>();
        boxCollider2D.isTrigger = true;
        rd.velocity = transform.right * throwSwordSpeed;
    }
    private void Update()
    {
        CurrentPosition = rd.velocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagebleAndKnockBack damageble = other.GetComponent<IDamagebleAndKnockBack>();
        if (other.gameObject.name == "Platform")
        {
            boxCollider2D.isTrigger = false;
            animator.SetBool("Grounded", true);
        }
        if (other.gameObject.tag == "Enemy")
        {
            if (other.transform.position.x < transform.position.x)
                KnockBack.x = 5 * -1;
            else
                KnockBack.x = 5;
            damageble.OnHit(damage);
            damageble.KnockBack(transform.position, 10);
            Destroy(gameObject);
        }
    }
    private void AnimationFinish()
    {
        // rd.velocity = CurrentPosition;
        Destroy(gameObject, 3f);
    }
}
