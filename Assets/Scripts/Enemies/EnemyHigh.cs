using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyHigh : Enemy
{
    public EnemyHigh()
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
