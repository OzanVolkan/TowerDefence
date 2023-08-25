using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyMid : Enemy
{
    public EnemyMid()
    {
        Speed = startSpeed;
    }
    void Start()
    {
        SetEnemyTarget();
    }

    void Update()
    {
        MoveToTarget();
        SetHealthBar();
    }
}
