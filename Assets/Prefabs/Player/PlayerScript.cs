using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    
    public List<GameObject> playerBody = new List<GameObject>();
    List<Vector3> lastBodyLocations = new List<Vector3>();

    public int playerBodyCount = 6;
    public bool allowedToMove = true;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            playerBody.Add(child.gameObject);
        }
    }

    public void MovePlayer(Vector2Int moveDirection)
    {
        if (allowedToMove)
        {
            SaveLastLocations();
            MoveHead(moveDirection);
            MoveBodyParts();
            GrowSnake();
        }
    }

    void SaveLastLocations()
    {
        lastBodyLocations.Clear();
        
        foreach (GameObject bodyPart in playerBody)
        {
            lastBodyLocations.Add(bodyPart.transform.position);
        }
    }

    void MoveHead(Vector2Int moveDirection)
    {
        if (moveDirection == new Vector2Int(0,1)) //UP
        {
            playerBody[0].transform.eulerAngles = new Vector3(0,0,0);
        }
        if (moveDirection == new Vector2Int(1,0)) //RIGHT
        {
            playerBody[0].transform.eulerAngles = new Vector3(0,0,-90);
        }
        if (moveDirection == new Vector2Int(0,-1)) //DOWN
        {
            playerBody[0].transform.eulerAngles = new Vector3(0,0,180);
        }
        if (moveDirection == new Vector2Int(-1,0)) //LEFT
        {
            playerBody[0].transform.eulerAngles = new Vector3(0,0,90);
        }
        
        // maybe check for collision
        playerBody[0].transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0), Space.World);
    }

    void MoveBodyParts()
    {
        for (int i = 1; i < playerBody.Count; i++)
        {
            playerBody[i].transform.position = lastBodyLocations[i-1];
        }
    }

    void GrowSnake()
    {
        if (playerBodyCount > playerBody.Count)
        {
            GameObject addToTail = Instantiate(bodyPartPrefab, lastBodyLocations[lastBodyLocations.Count - 1], Quaternion.identity);
            addToTail.transform.parent = this.gameObject.transform;
            addToTail.name = "Body (" + playerBody.Count + ")";

            playerBody.Add(addToTail);
        }
    }
}
