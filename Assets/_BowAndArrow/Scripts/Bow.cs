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
    public Transform pullingHand = null;

    private Arrow currentArrow = null;
    private bool isPulling = false;
    private Animator animator = null;

    private float pullValue = 0.0f;


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        createArrow();
    }

    private void Update() {
        if(!currentArrow || !isPulling) return;
        pullValue = calculatePull(pullingHand);
        pullValue = Mathf.Clamp(pullValue, 0.0f, 1.0f);

        animator.SetFloat("Blend", pullValue);
    }

    public void createArrow() {
        GameObject arrowObj = Instantiate(arrowPrefab, pullingHand);
        arrowObj.transform.localPosition = new Vector3(0, 0, 0.2f);
        arrowObj.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObj.GetComponent<Arrow>();
    }

    public float calculatePull(Transform pullHand) {
        Vector3 direction = end.position - start.position;
        float magnitude = direction.magnitude;
        direction.Normalize();

        Vector3 difference = pullHand.position - start.position;

        return Vector3.Dot(direction, difference) / magnitude;

    }

    public void pull() {
        float distance = Vector3.Distance(pullingHand.position, start.position);
        if (distance > grabThreshold) return;
        isPulling = true;
    }

    public void release() {
        if (pullValue > 0.25f) {
            fireArrow();
        }
        pullValue = 0.0f;
        animator.SetFloat("Blend", 0.0f);
        isPulling = false;
    }

    private void fireArrow() {
        currentArrow.fire(pullValue);
        currentArrow = null;
    }
}
