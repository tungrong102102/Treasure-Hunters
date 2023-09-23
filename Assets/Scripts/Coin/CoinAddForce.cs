using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAddForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private float DirX;
    private float DirY;
    private float torque;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void AddForce()
    {
        DirX = Random.Range(-5, 5);
        DirY = Random.Range(1, 3);
        torque = Random.Range(5, 15);
        rb.AddForce(new Vector2(DirX, DirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
    }
}
