using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [Header("Setup Fields")]
    [SerializeField] protected Transform partToRotate;
    [SerializeField] protected Transform firePoint;

    [Space(5)][ Header("Attributes")]
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;

    protected Transform target;    
    protected string enemyTag = "Enemy";
    protected float turnSpeed = 10f;
    protected float fireCountdown;

    protected void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    protected void RotateToEnemy()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    protected void ShootFire(string tag)
    {
        if (fireCountdown <= 0)
        {
            EventManager.Broadcast(GameEvent.OnSpawnFromPool, tag, firePoint.position, firePoint.rotation);
            fireCountdown = fireRate / 1f;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
