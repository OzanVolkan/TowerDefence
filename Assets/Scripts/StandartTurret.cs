using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartTurret : Turret
{
    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.25f);
    }

    private void Update()
    {
        if (target == null)
            return;

        RotateToEnemy();
    }

}
