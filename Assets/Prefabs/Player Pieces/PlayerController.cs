using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2Int playerLocation;
    public GameObject bodyPart;

    void Start()
    {
        playerLocation = new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }

    public void MovePlayer(Vector2Int moveDirection)
    {
        playerLocation += moveDirection;
        GameObject.Instantiate(bodyPart, (Vector2)playerLocation, Quaternion.identity);
    }
}
