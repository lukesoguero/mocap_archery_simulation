using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHand : MonoBehaviour
{
    public GameObject arrowPrefab = null;
    public Arrow currentArrow = null;
    // Start is called before the first frame update
    void Start()
    {
        //createArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createArrow() {
        GameObject arrowObj = Instantiate(arrowPrefab, transform);
        arrowObj.transform.localPosition = new Vector3(0, 0, 0.2f);
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public void dropArrow() {
        if (currentArrow) {
            Rigidbody rigidbody = currentArrow.GetComponent<Rigidbody>();
            currentArrow.transform.parent = null;

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;

            Destroy(currentArrow.gameObject, 6.0f);
            currentArrow = null;
        }
    }
}
