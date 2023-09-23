using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhap : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject ObjectEffect;

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CheckCoin")
        {
            Instantiate(ObjectEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
