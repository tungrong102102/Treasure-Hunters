using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {

        }
        else if (other.gameObject.tag == "RedPotion")
        {
            int currentHealth = GetComponentInParent<Player>().currentHealth + 10;
            if (currentHealth <= 100)
            {
                Debug.Log(currentHealth);
                GetComponentInParent<Player>().healthBarPlayer.SetHealth(currentHealth);
            }
        }
        else if (other.gameObject.tag == "GreenBottle")
        {
            int currentHealth = GetComponentInParent<Player>().currentHealth -= 10;
            GetComponentInParent<Player>().animator.SetTrigger("Hurt");
            GetComponentInParent<Player>().healthBarPlayer.SetHealth(currentHealth);
        }
    }
}
