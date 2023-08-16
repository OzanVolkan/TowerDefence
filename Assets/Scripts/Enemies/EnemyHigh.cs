using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHigh : Enemy
{
    public EnemyHigh()
    {
        Speed = 15f;
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
