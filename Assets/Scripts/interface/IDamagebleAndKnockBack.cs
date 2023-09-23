using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagebleAndKnockBack
{
    void OnHit(int damage);
    void KnockBack(Vector2 pos, float knockbackForce);
}
