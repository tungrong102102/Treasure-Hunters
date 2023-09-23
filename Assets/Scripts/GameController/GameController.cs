using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public Transform RespawnPos;
    private void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();
    }
    void Update()
    {

        player.lastPosition = RespawnPos.position;
        DontDestroyOnLoad(this.gameObject);
    }
}
