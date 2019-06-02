using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    public OutletType outletType;
    public float rechargeTime;
    public float rechargeTargetTime;
    GameObject otherCollidedObject;

    void FixedUpdate()
    {
        if (Time.time >= rechargeTargetTime)
        {
            this.GetComponentInParent<PlayerScript>().allowedToMove = true;
            if (otherCollidedObject != null) { otherCollidedObject.GetComponentInParent<PlayerScript>().allowedToMove = true; }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript thisPlayerScript = this.GetComponentInParent<PlayerScript>();

        otherCollidedObject = null;

        if (transform.parent.tag == "Active Player Head")
        {
            rechargeTargetTime = rechargeTime + Time.time;

            switch (other.tag)
            {
                case "Active Player Head":
                    Debug.Log("Hit a player head");
                    PlayerScript otherPlayerScript = other.GetComponentInParent<PlayerScript>();
                    otherCollidedObject = other.gameObject;
                    thisPlayerScript.allowedToMove = false;
                    otherPlayerScript.allowedToMove = false;
                    thisPlayerScript.PlayerPlugIn();
                    otherPlayerScript.PlayerPlugIn();
                    int averagebatterylife = (
                        thisPlayerScript.currentBatteryLife +
                        otherPlayerScript.currentBatteryLife
                        ) / 2;
                    thisPlayerScript.currentBatteryLife = averagebatterylife;
                    otherPlayerScript.currentBatteryLife = averagebatterylife;

                    break;

                case "Outlet":
                    Debug.Log(GetComponentInParent<OutletScript>().outletType);

                    if (other.GetComponent<OutletScript>().outletType != GetComponentInParent<OutletScript>().outletType)
                    {
                        Debug.Log("Hit an outlet");
                        thisPlayerScript.allowedToMove = false;
                        thisPlayerScript.PlayerPlugIn();
                        thisPlayerScript.currentBatteryLife = thisPlayerScript.maxBatteryLife;
                    }
                    break;
            }
        }
    }
}
