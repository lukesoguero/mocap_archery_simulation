using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject arrowPrefab = null;

    [Header("Bow")]
    public float grabThreshold = 0.15f;
    public Transform end = null;
    public Transform start = null;
    public Transform socket = null;

    private Transform pullingHand = null;
    private Arrow currentArrow = null;
    private Animator animator = null;

    private float pullValue = 0.0f;


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        createArrow();
    }

    private void createArrow() {
        GameObject arrowObj = Instantiate(arrowPrefab, socket);
        arrowObj.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public void pull(Transform hand) {

    }

    public void release() {

    }
}
