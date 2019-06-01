using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    public OutletType outletType;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.parent.tag == "Active Player Head")
        {
            switch (other.tag)
            {
                case "Active Player Head":
                    Debug.Log("Hit a player head");
                    this.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    other.GetComponentInParent<PlayerScript>().allowedToMove = false;
                    this.GetComponentInParent<PlayerScript>().PlayerPlugIn();
                    other.GetComponentInParent<PlayerScript>().PlayerPlugIn();
                    this.GetComponentInParent<PlayerScript>().allowedToMove = true;
                    other.GetComponentInParent<PlayerScript>().allowedToMove = true;
                    break;

                case "Outlet":
                    Debug.Log("Hit an outlet");
                    break;
            }
        }
    }
}
