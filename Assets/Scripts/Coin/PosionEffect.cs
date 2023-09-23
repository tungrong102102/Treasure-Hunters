using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionEffect : MonoBehaviour
{
    public GameObject ObjectEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CheckCoin")
        {
            Instantiate(ObjectEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
