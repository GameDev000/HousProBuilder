using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireParticles;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (fireParticles == null) return;

        if (!fireParticles.isPlaying)
            fireParticles.Play();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (fireParticles == null) return;

        fireParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}