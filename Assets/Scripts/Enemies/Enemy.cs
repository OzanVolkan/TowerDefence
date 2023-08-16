using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    protected float Speed { get; set; }

    private Transform target;
    private int wavepointIndex;
    protected void SetEnemyTarget()
    {
        target = WayPoint.points[0];
    }

    protected void MoveToTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position,target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }
    
    protected void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }

}
