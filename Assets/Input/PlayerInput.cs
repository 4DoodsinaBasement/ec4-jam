using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public enum PlayerID { Player1 = 0, Player2 = 1 }

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public PlayerID playerID;
    Player player;
    PlayerController playerController;
    Vector2Int moveDirection;

    void Awake()
    {
        player = ReInput.players.GetPlayer((int)playerID);
        playerController = GetComponent<PlayerController>();
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
        playerController.MovePlayer(moveDirection);
    }
}
