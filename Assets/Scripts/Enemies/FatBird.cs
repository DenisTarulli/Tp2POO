using System.Collections;
using UnityEngine;

public class FatBird : Enemy
{
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float fallingSpeedIncreaseMultiplier;
    [SerializeField] private float returnSpeed;
    [SerializeField] private float timeOnGround;
    private bool isAttacking;
    private bool groundReached;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        groundReached = false;
    }

    protected override void Attack()
    {
        isAttacking = true;

        animator.SetTrigger("attack");

        StartCoroutine(FallAndReturn());
    }

    public void TriggerAttack()
    {
        if (isAttacking) return;

        Attack();
    }

    private IEnumerator FallAndReturn()
    {
        float incresingFallSpeed = fallingSpeed;

        while (!groundReached)
        {
            transform.Translate(incresingFallSpeed * Time.deltaTime * Vector2.down);

            incresingFallSpeed += Time.deltaTime * fallingSpeedIncreaseMultiplier;

            if (Vector2.Distance(transform.position, points[1].position) <= distanceToPoint)            
                groundReached = true;

            yield return null;
        }

        animator.SetTrigger("ground");

        yield return new WaitForSeconds(timeOnGround);
        groundReached = false;

        while (Vector2.Distance(transform.position, points[0].position) > distanceToPoint)
        {
            transform.Translate(returnSpeed * Time.deltaTime * Vector2.up);
            
            yield return null;
        }

        transform.position = points[0].position;
        isAttacking = false;
    }    
}
