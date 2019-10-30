using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
    public Bow bow = null;
    public CustomHand hand = null; 
    public GameObject quiver = null;
    

    private void Update()
    {
        OVRInput.Update();
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey("space")) {
            // If player is reaching into quiver
            if (quiver.GetComponent<Collider>().bounds.Contains(hand.transform.position)) {
                hand.createArrow();
            }
            else {
                bow.pull();
            }
        }

        if (Input.GetKeyUp("space") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
            bow.release();
            hand.dropArrow();
        }
    }
}
