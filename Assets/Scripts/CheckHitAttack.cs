using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitAttack : MonoBehaviour
{
    public Vector2 knockback;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagebleAndKnockBack idamageAndKnockBack = other.GetComponent<IDamagebleAndKnockBack>();
        if (idamageAndKnockBack != null)
        {
            if (other.transform.position.x < transform.position.x)
                knockback.x = 5 * -1;
            else
                knockback.x = 5;
            idamageAndKnockBack.OnHit(damage);
            if (other.gameObject.name != "Boss")
                idamageAndKnockBack.KnockBack(transform.position, 10);
        }
    }
}
