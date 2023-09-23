using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsHealthPos : MonoBehaviour
{
    public GameObject HealthPos;
    public float insTime;
    public float startTime;
    private void Update()
    {
        if (Time.time >= startTime + insTime)
        {
            startTime = Time.time;
            if (transform.childCount == 0)
            {
                Instantiate(HealthPos, transform);
            }
        }
    }
}
