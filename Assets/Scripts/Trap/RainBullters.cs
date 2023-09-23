using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBullters : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    public GameObject buller;
    private bool PlayerTrigger = false;
    public float TimeBullet = 1f;
    private float StartTime;
    private void Start()
    {
        StartTime = Time.time;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (PlayerTrigger && Time.time >= StartTime)
        {
            StartTime = Time.time + TimeBullet;
            int rad = Random.Range(-(int)boxCollider2D.size.x, (int)boxCollider2D.size.x);
            Instantiate(buller, new Vector3(transform.position.x + rad / 2, transform.position.y + boxCollider2D.size.y / 2, 0), transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerTrigger = false;
        }
    }
}
