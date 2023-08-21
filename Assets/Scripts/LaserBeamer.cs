using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamer : Turret
{
    [SerializeField] LineRenderer lineRenderer;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.25f);
    }
    private void Update()
    {
        if (target == null)
        {
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;

            return;
        }

        RotateToEnemy();
        Laser();
    }
    void Laser()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
}
