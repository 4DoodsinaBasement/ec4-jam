using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    PlayerScript myPlayerScript;
    PlayerScript thisPlayerScript;

    void Start()
    {
        myPlayerScript = GetComponentInParent<PlayerScript>();
        thisPlayerScript = this.GetComponentInParent<PlayerScript>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "Active Player Head")
        {
            switch (other.tag)
            {

                case "Wall":
                    Debug.Log("Hit a wall");
                    thisPlayerScript.allowedToMove = false;
                    // INSERT DEATH
                    break;

                case "Orb":
                    if (CanPickup(other.gameObject))
                    {
                        Debug.Log("EAT");
                        myPlayerScript.playerBodyCount += GameMaster.Instance.orbAddAmount;
                        Destroy(other.gameObject);
                    }
                    break;

                case "Player Body":
                    Debug.Log("Hit a player body");
                    thisPlayerScript.allowedToMove = false;
                    break;
            }
        }
    }

    bool CanPickup(GameObject orbObject)
    {
        GameColor orbColor = orbObject.GetComponent<OrbScript>().orbColor;

        return (orbColor == myPlayerScript.playerColor);
    }
}
