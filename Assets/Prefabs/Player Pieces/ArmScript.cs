using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    public OutletType outletType;
    public float rechargeTime;
    public float rechargeTargetTime;
    GameObject otherPlayer;

    void FixedUpdate()
    {
        if (Time.time >= rechargeTargetTime)
        {
            this.GetComponentInParent<PlayerScript>().allowedToMove = true;
            otherPlayer.GetComponentInParent<PlayerScript>().allowedToMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.parent.tag == "Active Player Head")
        {
            rechargeTargetTime = rechargeTime + Time.time;
            otherPlayer = other.gameObject;
            switch (other.tag)
            {
                case "Active Player Head":
                    Debug.Log("Hit a player head");
                    this.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    other.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    this.GetComponentInParent<PlayerScript>().PlayerPlugIn();
                    other.GetComponentInParent<PlayerScript>().PlayerPlugIn();

                    break;

                case "Outlet":
                    Debug.Log("Hit an outlet");
                    break;
            }
        }
    }
}
