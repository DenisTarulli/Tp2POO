using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] protected EnemyScriptableObject enemy;
    [SerializeField] protected float distanceToPoint;
    [SerializeField] protected Transform[] points;
    protected Transform targetPoint;
    protected float currentHealth;

    protected virtual void Movement()
    {
        Vector2 dir = GetDirection(targetPoint);

        transform.Translate(enemy.moveSpeed * Time.deltaTime * dir.normalized);
    }

    protected abstract void Attack();


    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
    }

    protected void SetTarget()
    {
        if (targetPoint == null)
            targetPoint = points[0];

        float distance = Vector2.Distance(transform.position, targetPoint.position);

        if (distance > distanceToPoint) return;

        for (int i = 0; i < points.Length; i++)
        {
            if (targetPoint != points[i])
            {
                targetPoint = points[i];
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