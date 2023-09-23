using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsSword : MonoBehaviour
{
    private float startTime;
    public float instanceTime;
    public GameObject Sword;

    private void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Sword");
        if (gameObject != null)
        {
            return;
        }
        else
        {
            if (Time.time >= startTime + instanceTime)
            {
                startTime = Time.time;
                Instantiate(Sword, transform.position, transform.rotation);
            }
        }
    }
}
