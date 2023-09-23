using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDown : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    public Vector2 knockback;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagebleAndKnockBack idamageAndKnockBack = other.GetComponent<IDamagebleAndKnockBack>();

        if (other.GetComponent<Player>() != null)
        {
            rb.velocity = Vector2.zero;
            if (other.transform.position.x < transform.position.x)
                knockback.x = 5 * -1;
            else
                knockback.x = 5;
            idamageAndKnockBack.OnHit(damage);
            animator.SetTrigger("Destroy");
        }
        if (other.gameObject.name != "RainBullets")
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("Destroy");
        }
    }
}
