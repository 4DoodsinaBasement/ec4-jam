using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    GameMaster master;
    
    public OutletType outletType;
    public float rechargeTime;
    public float rechargeTargetTime;
    GameObject otherCollidedObject;

    void Start()
    {
        master =  GameObject.Find("Game Master").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I hit " + other.gameObject.name);
        PlayerScript thisPlayerScript = this.GetComponentInParent<PlayerScript>();

        otherCollidedObject = null;

        if (transform.parent.tag == "Active Player Head")
        {
            rechargeTargetTime = rechargeTime + Time.time;

            switch (other.tag)
            {
                case "Active Player Head":
                    Debug.Log("We were supposed to win: " + master.OrbsCollected());
                    if (master.OrbsCollected())
                    {
                        master.WinGame();
                    }

                    PlayerScript otherPlayerScript = other.GetComponentInParent<PlayerScript>();
                    otherCollidedObject = other.gameObject;
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

                case "Outlet":
                    if (other.GetComponent<OutletScript>().outletType != GetComponentInParent<OutletScript>().outletType)
                    {
                        thisPlayerScript.PlayerPlugIn();
                        thisPlayerScript.currentBatteryLife = thisPlayerScript.maxBatteryLife;
                    }
                    else
                    {
                        master.LoseGame();
                    }
                    break;
            }
        }
    }
}
