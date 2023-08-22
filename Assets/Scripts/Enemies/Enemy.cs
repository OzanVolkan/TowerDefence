using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] protected float health;
    [SerializeField] protected float startSpeed;
    [SerializeField] protected int moneyReward;

    [Header("Particle")]
    [SerializeField] protected GameObject deathEffect;
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

        Speed = startSpeed;
    }
    
    protected void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoint.points.Length - 1)
        {
            GameManager.Instance.GetDamage();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
        return;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        Speed = startSpeed * (1 - amount);
    }

    private void Die()
    {
        DataManager.Instance.gameData.Money += moneyReward;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}
