using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    [SerializeField] private Transform lid;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 10f;

    private Quaternion closedRot;
    private Quaternion openRot;
    private bool playerInside;

    void Awake()
    {
        closedRot = lid.localRotation;
        openRot = closedRot * Quaternion.Euler(openAngle, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = false;
    }

    void Update()
    {
        if (lid == null) return;

        Quaternion target = playerInside ? openRot : closedRot;
        lid.localRotation = Quaternion.Slerp(lid.localRotation, target, openSpeed * Time.deltaTime);
    }
}
