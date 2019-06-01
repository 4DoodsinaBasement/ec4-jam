using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
         
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player Body":
                Debug.Log("Hit a player body");
                break;

            case "Wall":
                Debug.Log("Hit a wall");
                break;
                
            case "Orb":
                Debug.Log("Hit an Orbuh");
                break;
        }
    }
}
