using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            other.GetComponent<Player>().lastPosition = new Vector3(-21, 0, 0);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(other);
            other.GetComponent<Player>().LoadPosition();

        }
    }
}
