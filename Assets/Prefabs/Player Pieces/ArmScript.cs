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
        otherCollidedObject = null;
        
        if (transform.parent.tag == "Active Player Head")
        {
            rechargeTargetTime = rechargeTime + Time.time;

            switch (other.tag)
            {
                case "Active Player Head":
                    // check Win Condition
                    GameMaster master =  GameObject.Find("Game Master").GetComponent<GameMaster>();
                    if (master.OrbsCollected())
                    {
                        Debug.Log("Win in arm");
                        master.WinGame();
                    }

                    Debug.Log("Hit a player head");
                    otherCollidedObject = other.gameObject;
                    this.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    other.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    this.GetComponentInParent<PlayerScript>().PlayerPlugIn();
                    other.GetComponentInParent<PlayerScript>().PlayerPlugIn();
                    break;

                case "Outlet":
                    Debug.Log(GetComponentInParent<OutletScript>().outletType);
                    
                    if (other.GetComponent<OutletScript>().outletType != GetComponentInParent<OutletScript>().outletType)
                    {
                        Debug.Log("Hit an outlet");
                        PlayerScript thisPlayerScript = this.GetComponentInParent<PlayerScript>();
                        thisPlayerScript.allowedToMove = false;
                        thisPlayerScript.PlayerPlugIn();
                        thisPlayerScript.currentBatteryLife = thisPlayerScript.maxBatteryLife;
                    }
                    break;
            }
        }
    }
}
