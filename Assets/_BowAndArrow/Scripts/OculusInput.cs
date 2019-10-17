using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
    public Bow m_Bow = null;
    public GameObject m_OppositeController = null;
    //public OVRInput.Controller m_Controller = OVRInput.Controller.None;

    private void Update()
    {
        OVRInput.Update();
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            Debug.Log("Pressed");
            m_Bow.pull(m_OppositeController.transform);
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            m_Bow.release();
    }
}
