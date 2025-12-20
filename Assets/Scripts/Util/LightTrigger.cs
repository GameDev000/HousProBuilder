using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private Light targetLight;
    [SerializeField] private bool turnOnWhenNear = true;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (targetLight == null) return;

        targetLight.enabled = turnOnWhenNear;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (targetLight == null) return;

        targetLight.enabled = !turnOnWhenNear;
    }
}
