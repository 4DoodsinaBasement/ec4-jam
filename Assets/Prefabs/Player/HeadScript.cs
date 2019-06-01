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
        Debug.Log("We haven't completely failed at life...?");
        Debug.Log("Collided with " + other.gameObject.name);
    }
}
