using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipNextLevel : MonoBehaviour
{
    public Vector2 WorkSpaceVector;
    public float Speed = 3f;
    private Rigidbody2D rb;
    public Animator animatorSail;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = transform.position + new Vector3(Speed, 0, 0);
            other.transform.SetParent(this.transform);
            animatorSail.SetBool("Wind", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animatorSail.SetBool("Wind", false);
            animatorSail.SetBool("Idle", true);
        }
    }
}
