using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeadScript : MonoBehaviour
{
    PlayerScript myPlayerScript;
    PlayerScript thisPlayerScript;

    GameMaster master;

    void Start()
    {
        master = GameObject.Find("Game Master").GetComponent<GameMaster>();
        
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
                case "Active Player Head":
                    Debug.Log("We were supposed to win: " + master.OrbsCollected());
                    if (master.OrbsCollected())
                    {
                        master.WinGame();
                    }

                    PlayerScript otherPlayerScript = other.GetComponentInParent<PlayerScript>();
                    thisPlayerScript.allowedToMove = false;
                    otherPlayerScript.allowedToMove = false;
                    thisPlayerScript.PlayerPlugIn();
                    otherPlayerScript.PlayerPlugIn();
                    int averagebatterylife = (
                        thisPlayerScript.currentBatteryLife +
                        otherPlayerScript.currentBatteryLife
                    ) * 2;
                    thisPlayerScript.currentBatteryLife = averagebatterylife;
                    otherPlayerScript.currentBatteryLife = averagebatterylife;

                    break;
                
                
                case "Wall":
                    master.LoseGame();
                    break;

                case "Orb":
                    if (CanPickup(other.gameObject))
                    {   GameMaster master = GameObject.Find("Game Master").GetComponent<GameMaster>();
                        myPlayerScript.playerBodyCount += master.orbAddAmount;
                        master.FoodCollected(other.GetComponent<OrbScript>().orbColor);
                    }
                    break;

                case "Player Body":
                    master.LoseGame();
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
