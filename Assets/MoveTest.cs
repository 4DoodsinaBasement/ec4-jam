using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;
    public float moveSpeed = 3.0f;
    
    public Vector3 moveVector;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(0);
    }

    void Update ()
    {
        GetInput();
        ProcessInput();

        if (player.GetButtonDown("Button"))
        {
            Debug.Log("BUTTTTTTON!!!!!!!!!");
        }
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("MoveHorizontal");
        moveVector.y = player.GetAxis("MoveVertical");
    }

    private void ProcessInput()
    {
        Debug.Log("INSIDE PROCESS INPUT");
        if(moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            rb.velocity = moveVector/* * moveSpeed * Time.deltaTime*/;
        }
    }
}
