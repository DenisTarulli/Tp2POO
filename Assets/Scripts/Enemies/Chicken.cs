using System.Collections;
using UnityEngine;

public class Chicken : Enemy
{
    private Transform playerPosition;
    private float distanceToTarget;
    private bool isAttacking;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            GetDistanceToTarget();
            FlipSprite(GetDirection(currentTarget));
        }

    }
    protected override void Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);
        SetTarget();
        StartCoroutine(Charge());
    }

    protected override void SetTarget()
    {
        Vector2 toPlayerDir = playerPosition.position - transform.position;

        if (toPlayerDir.x < 0f)
            currentTarget = points[0];
        else
            currentTarget = points[1];
    }

    public void TriggerAttack(Transform newTarget)
    {
        if (isAttacking) return;

        playerPosition = newTarget;
        Attack();
    }

    private void GetDistanceToTarget()
    {
        distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
    }

    private IEnumerator Charge()
    {
        Vector2 dir = GetDirection(currentTarget);

        yield return new WaitForEndOfFrame();
        
        while (distanceToTarget > distanceToPoint)
        {
            transform.Translate(enemy.moveSpeed * Time.deltaTime * dir.normalized);

            yield return null;
        }

        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }
}
