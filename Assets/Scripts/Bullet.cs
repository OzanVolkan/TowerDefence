using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] GameObject bulletImpactEffect;

    [Header("Attributes")]
    [SerializeField] float speed;
    [SerializeField] float expolosionRadius;

    Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dstThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= dstThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * dstThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject impactEff = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(impactEff, 5f);

        if (expolosionRadius < 0f)
        {
            Explode();
        }
        else
        {
            Destroy(target.gameObject);
        }

        gameObject.SetActive(false);
    }

    private void Explode()
    {
        int enemyLayer = 6;
        Collider[] colliders = Physics.OverlapSphere(transform.position, expolosionRadius, 1 << enemyLayer);
        foreach (Collider collider in colliders)
        {
            Damage(collider.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, expolosionRadius);
    }
}
