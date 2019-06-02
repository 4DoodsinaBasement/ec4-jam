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
    public Vector2Int inputDirection;
    GameColor color;

    void Awake()
    {
        player = ReInput.players.GetPlayer((int)playerID);
        playerScript = GetComponent<PlayerScript>();
        GameColor color = playerScript.playerColor;
        //inputDirection = new Vector2Int(0,1);
        /**/
        switch (color)
        {
            case GameColor.Blue:
                inputDirection = new Vector2Int(1, 0);
                break;
            case GameColor.Red:
                inputDirection = new Vector2Int(-1, 0);
                break;
        }
        /**/
    }

    void Update()
    {
        if (player.GetButtonDown("Move Up") && inputDirection.y != -1)
        {
            inputDirection.x = 0;
            inputDirection.y = 1;
        }

        if (player.GetButtonDown("Move Right") && inputDirection.x != -1)
        {
            inputDirection.x = 1;
            inputDirection.y = 0;
        }

        if (player.GetButtonDown("Move Down") && inputDirection.y != 1)
        {
            inputDirection.x = 0;
            inputDirection.y = -1;
        }

        if (player.GetButtonDown("Move Left") && inputDirection.x != 1)
        {
            inputDirection.x = -1;
            inputDirection.y = 0;
        }
    }

    public void ReversePlayerDirection()
    {
        inputDirection.x = -inputDirection.x;
        inputDirection.y = -inputDirection.y;
    }
}
