using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonNextLevel : MonoBehaviour
{
    public GameObject camera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            other.GetComponent<Player>().lastPosition = new Vector3(-21, 0, 0);
            other.GetComponent<Player>().LoadPosition();
            DontDestroyOnLoad(other);
            DontDestroyOnLoad(camera);
        }
    }
}
