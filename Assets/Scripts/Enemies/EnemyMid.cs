using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMid : Enemy
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
    }
}
