using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public IDamagebleAndKnockBack knockBack;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<IDamagebleAndKnockBack>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagebleAndKnockBack idamagebleandknockback = other.GetComponent<IDamagebleAndKnockBack>();
        if (idamagebleandknockback != null)
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
