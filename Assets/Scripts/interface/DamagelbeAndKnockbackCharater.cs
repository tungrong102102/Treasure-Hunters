using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagelbeAndKnockbackCharater : MonoBehaviour, IDamagebleAndKnockBack
{
    public int maxHealth;
    public int currentHealth;
    public HealthBarPlayer healthBarPlayer;
    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBarPlayer.SetMaxHealth(currentHealth);
    }
    public void OnHit(int damage)
    {
        currentHealth -= damage;
        healthBarPlayer.SetHealth(currentHealth);
        animator.SetBool("Hurt", true);
    }
    public void KnockBack(Vector2 KnockBack)
    {
        // rb.velocity = new Vector2((KnockBack.x * direction), KnockBack.y + rb.velocity.y);
        rb.AddForce(KnockBack, ForceMode2D.Impulse);
        // Debug.Log(KnockBack * direction);
    }

    public void KnockBack(Vector2 pos, float knockbackForce)
    {
        throw new System.NotImplementedException();
    }
}
