using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLow : Enemy
{
    public EnemyLow()
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
    }
}
