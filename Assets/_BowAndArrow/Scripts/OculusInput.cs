using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
    public Bow m_Bow = null;
    public GameObject quiver = null;
    public GameObject m_OppositeController = null;

    private void Update()
    {
        OVRInput.Update();
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown("space")) {
            // If player is reaching into quiver
            if (quiver.GetComponent<Collider>().bounds.Contains(m_OppositeController.transform.position)) {
                m_Bow.createArrow();
            }
            else {
                m_Bow.pull();
            }
        }

        if (Input.GetKeyUp("space") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
            m_Bow.release();
        }
    }
}
