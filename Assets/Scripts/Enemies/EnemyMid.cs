using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMid : Enemy
{
    public EnemyMid()
    {
        Speed = 10f;
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
