using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Fire")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float range = 30f;
    [SerializeField] private int damage = 10;
    [SerializeField] private LayerMask shootMask;
    [SerializeField] private float targetGap = 5f;

    [Header("Visual")]
    [SerializeField] private LineRenderer tracer;
    [SerializeField] private float tracerTime = 0.05f;

    private float nextFireTime;

    void Awake()
    {
        if (tracer != null)
            tracer.enabled = false;
    }

    void Update()
    {
        if (player == null) return;
        if (Time.time < nextFireTime) return;

        Shoot();

        nextFireTime = Time.time + fireRate;
    }

    private void Shoot()
    {
        Vector3 origin = (firePoint != null) ? firePoint.position : transform.position + Vector3.up * 1.5f;
        Vector3 aimPoint = player.position + Vector3.up * targetGap;
        Vector3 dir = (aimPoint - origin).normalized;

        bool hitSomething = Physics.Raycast(origin, dir, out RaycastHit hit, range, shootMask, QueryTriggerInteraction.Ignore);

        Vector3 endPoint = hitSomething ? hit.point : (origin + dir * range);
        if (tracer != null)
            StartCoroutine(ShowTracer(origin, endPoint));


        if (hitSomething)
        {
            var hp = hit.collider.GetComponentInParent<PlayerHealth>();

            if (hp != null)
                hp.TakeDamage(damage);
        }
    }

    private IEnumerator ShowTracer(Vector3 start, Vector3 end)
    {
        tracer.SetPosition(0, start);
        tracer.SetPosition(1, end);

        tracer.enabled = true;
        yield return new WaitForSeconds(tracerTime);
        tracer.enabled = false;
    }
}
