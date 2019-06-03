using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeadScript : MonoBehaviour
{
    PlayerScript myPlayerScript;
    
    void Start()
    {
        myPlayerScript = GetComponentInParent<PlayerScript>();
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
                if (CanPickup(other.gameObject))
                {
                    Debug.Log("EAT");
                    myPlayerScript.playerBodyCount += GameMaster.Instance.orbAddAmount;

                    GameMaster master =  GameObject.Find("Game Master").GetComponent<GameMaster>();

                    master.FoodCollected(other.GetComponent<OrbScript>().orbColor);
                    //Destroy(other.gameObject);
                }
                break;
        }
    }

    bool CanPickup(GameObject orbObject)
    {
        GameColor orbColor = orbObject.GetComponent<OrbScript>().orbColor;

        return (orbColor == myPlayerScript.playerColor);
    }
}
