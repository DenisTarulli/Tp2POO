using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] protected EnemyScriptableObject enemy;
    [SerializeField] protected float distanceToPoint;
    [SerializeField] protected Transform[] points;
    protected Transform currentTarget;
    protected float currentHealth;

    protected virtual void Movement()
    {
        Vector2 dir = GetDirection(currentTarget);

        transform.Translate(enemy.moveSpeed * Time.deltaTime * dir.normalized);
    }

    protected abstract void Attack();


    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
    }

    protected virtual void SetTarget()
    {
        if (currentTarget == null)
            currentTarget = points[0];

        float distance = Vector2.Distance(transform.position, currentTarget.position);

        if (distance > distanceToPoint) return;

        for (int i = 0; i < points.Length; i++)
        {
            if (currentTarget != points[i])
            {
                currentTarget = points[i];
                return;
            }
        }
    }

    protected Vector2 GetDirection(Transform target)
    {
        Vector2 dir = target.position - transform.position;

        return dir;
    }

    protected void FlipSprite(Vector2 direction)
    {
        if (direction.x > 0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            transform.localScale = Vector3.one;
    }
}