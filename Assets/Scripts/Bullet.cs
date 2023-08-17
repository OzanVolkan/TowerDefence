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
    }

    private void HitTarget()
    {
        GameObject impactEff = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(impactEff, 2f);

        Destroy(target.gameObject);
        gameObject.SetActive(false);
    }
}
