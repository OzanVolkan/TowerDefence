using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] protected float startSpeed;
    [SerializeField] protected float damageReducer;
    [SerializeField] protected int moneyReward;

    [Header("Effects")]
    [SerializeField] protected GameObject deathEffect;
    [SerializeField] protected Transform healthCanvas;
    [SerializeField] protected Image healthBar;

    protected float Speed { get; set; }

    private Transform target;
    private int wavepointIndex;
    private float health = 100f;
    private float healthTempAmount;
    private float healthReduceSpeed = 10f;
    protected void SetEnemyTarget()
    {
        target = WayPoint.points[0];
    }

    protected void MoveToTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
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
        health -= amount / damageReducer;

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

    protected void SetHealthBar()
    {
        healthTempAmount = health / 100f;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, healthTempAmount, healthReduceSpeed * Time.deltaTime);
    }
}
