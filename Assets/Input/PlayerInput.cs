using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public enum PlayerID { Player1 = 0, Player2 = 1 }

[RequireComponent(typeof(PlayerScript))]
public class PlayerInput : MonoBehaviour
{
    public PlayerID playerID;
    Player player;
    PlayerScript playerScript;
    Vector2Int moveDirection;

    void Awake()
    {
        player = ReInput.players.GetPlayer((int)playerID);
        playerScript = GetComponent<PlayerScript>();
        moveDirection = new Vector2Int(0,1);
    }

    void Update()
    {
        if (player.GetButtonDown("Move Up") && moveDirection.y != -1)
        {
            moveDirection.x = 0;
            moveDirection.y = 1;
        }

        if (player.GetButtonDown("Move Right") && moveDirection.x != -1)
        {
            moveDirection.x = 1;
            moveDirection.y = 0;
        }

        if (player.GetButtonDown("Move Down") && moveDirection.y != 1)
        {
            moveDirection.x = 0;
            moveDirection.y = -1;
        }

        if (player.GetButtonDown("Move Left") && moveDirection.x != 1)
        {
            moveDirection.x = -1;
            moveDirection.y = 0;
        }
    }

    void FixedUpdate()
    {
        playerScript.MovePlayer(moveDirection);
    }
}
