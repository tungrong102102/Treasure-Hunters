using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private float DirX;
    private float DirY;
    private float torque;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DirX = Random.Range(-5, 5);
        DirY = Random.Range(1, 3);
        torque = Random.Range(5, 15);
        rb.AddForce(new Vector2(DirX, DirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);

        Destroy(gameObject, 3f);
    }
}
